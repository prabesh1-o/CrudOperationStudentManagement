using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StudentManagment.Application.CQRS.Commands
{
    public class DeleteCourseCommand : IRequest<Unit>
    {
        public int CourseID { get; set; }
        public DeleteCourseCommand(int courseId)
        {
            CourseID = courseId;
        }
    }
}
