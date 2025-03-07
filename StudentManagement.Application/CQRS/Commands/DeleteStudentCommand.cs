using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StudentManagment.Application.CQRS.Commands
{

    public class DeleteStudentCommand : IRequest<Unit> // ✅ Ensure it implements IRequest<Unit>
    {
        public int StudentID { get; set; }

        public DeleteStudentCommand(int studentId)
        {
            StudentID = studentId;
        }
    }

}
// HandCrafted By Rohan Thapa