using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StudentManagment.Application.CQRS.Commands
{
    public class DeleteEnrollmentCommand : IRequest<Unit>
    {
        public int EnrollmentID { get; set; }
        public DeleteEnrollmentCommand(int enrollmentId)
        {
            EnrollmentID = enrollmentId;
        }
    }
}
