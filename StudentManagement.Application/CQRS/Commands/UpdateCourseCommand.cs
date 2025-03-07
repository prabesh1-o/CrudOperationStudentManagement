using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StudentManagment.Application.CQRS.Commands
{
    public class UpdateCourseCommand : IRequest<Unit>
    {
        public int CourseID { get; set; }
        public string? CourseName { get; set; }
        public string? CourseCode { get; set; }
        public int CreditHours { get; set; }

        public UpdateCourseCommand(int courseID, string? courseName, string? courseCode, int creditHours)
        {
            CourseID = courseID;
            CourseName = courseName;
            CourseCode = courseCode;
            CreditHours = creditHours;
        }
    }
}
