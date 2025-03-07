using AutoMapper;
using MediatR;
using StudentManagement.Core.Entity;
using StudentManagment.Application.CQRS.Commands;

using StudentManagment.Core.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StudentManagment.Application.CQRS.Handlers.Grades
{
    public class UpdateGradeHandler : IRequestHandler<UpdateGradeCommand, Unit>
    {
        private readonly IRepository<Grade> _repository;
        private readonly IMapper _mapper;

        public UpdateGradeHandler(IRepository<Grade> repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        public async Task<Unit> Handle(UpdateGradeCommand request, CancellationToken cancellationToken)
        {
            var grade = await _repository.GetByIdAsync(request.GradeID);
            if (grade == null)
            {
                throw new KeyNotFoundException("Grade not found");
            }

            grade.StudentID = request.StudentID;
            grade.CourseID = request.CourseID;
            grade.LetterGrade = request.LetterGrade;

            await _repository.UpdateAsync(grade);
            return Unit.Value;
        }
    }
}
