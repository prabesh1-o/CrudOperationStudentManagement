using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StudentManagment.Application.CQRS.Commands
{
    public class DeleteGradeCommand : IRequest<Unit>
    {
        public int GradeID { get; set; }
        public DeleteGradeCommand(int gradeId)
        {
            GradeID = gradeId;
        }
    }
}
