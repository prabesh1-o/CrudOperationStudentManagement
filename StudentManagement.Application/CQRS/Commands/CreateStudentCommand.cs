using MediatR;
using StudentManagement.Application.DTOs;

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StudentManagment.Application.CQRS.Commands
{
    public record CreateStudentCommand(string FullName, string Email, string PhoneNumber) : IRequest<StudentDTO>;
}
