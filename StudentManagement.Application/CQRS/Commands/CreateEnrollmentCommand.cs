using MediatR;
using StudentManagement.Application.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StudentManagement.Application.CQRS.Commands
{
    public record  CreateEnrollmentCommand(int StudentID, int CourseID, DateTime EnrollmentDate) : IRequest<EnrollmentDTO>;
    
}
