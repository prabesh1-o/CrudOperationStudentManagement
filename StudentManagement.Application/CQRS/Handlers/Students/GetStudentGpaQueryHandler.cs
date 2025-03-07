using MediatR;
using Microsoft.EntityFrameworkCore;
using StudentManagement.Application.DTOs;
using StudentManagement.Application.Interfaces;
using StudentManagment.Application.CQRS.Queries;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StudentManagment.Application.CQRS.Handlers.Students
{
    public class GetStudentGpaQueryHandler : IRequestHandler<GetStudentGpaQuery, StudentGpaDTO>
    {
        private readonly IAppDbContext _context;
        public GetStudentGpaQueryHandler(IAppDbContext context)
        {
            _context = context;
        }
        public async Task<StudentGpaDTO> Handle(GetStudentGpaQuery request, CancellationToken cancellationToken)
        {
            var student = await _context.Students.FindAsync(new object[] { request.StudentID }, cancellationToken);
            if (student == null)
            {
                throw new KeyNotFoundException($"Student with {request.StudentID} not found!");
            }

            var gradeRecords = await _context.Grades
                .Where(g => g.StudentID == request.StudentID)
                .Join(_context.Courses,
                    g => g.CourseID,
                    c => c.CourseID,
                    (g, c) => new { g.LetterGrade, c.CreditHours })
                .ToListAsync(cancellationToken);

            double numerator = 0;
            int denominator = 0;
            foreach(var record in gradeRecords)
            {
                double gradePoint = GetGradePoint(record.LetterGrade);
                numerator += gradePoint * record.CreditHours;
                denominator += record.CreditHours;
            }
            double gpa = denominator > 0 ? numerator / denominator : 0;

            return new StudentGpaDTO
            {
                StudentID = student.StudentID,
                FullName = student.FullName,
                GPA = gpa
            };
        }

        private double GetGradePoint(char grade)
        {
            return grade switch
            {
                'A' => 4.0,
                'B' => 3.0,
                'C' => 2.0,
                'D' => 1.0,
                'F' => 0.0,
                _ => 0.0
            };
        }
    }
}
