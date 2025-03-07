using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StudentManagment.Application.CQRS.Commands
{
    public class UpdateStudentCommand : IRequest<Unit> // ✅ Ensure it implements IRequest<Unit>
    {
        public int StudentID { get; set; }
        public string? FullName { get; set; }
        public string? Email { get; set; }
        public string? PhoneNumber { get; set; }

        public UpdateStudentCommand(int studentId, string? fullName, string? email, string? phoneNumber)
        {
            StudentID = studentId;
            FullName = fullName;
            Email = email;
            PhoneNumber = phoneNumber;
        }
    }

}
