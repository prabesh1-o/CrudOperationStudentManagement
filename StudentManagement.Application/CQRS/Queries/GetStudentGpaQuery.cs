using MediatR;
using StudentManagement.Application.DTOs;

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StudentManagment.Application.CQRS.Queries
{
    public class GetStudentGpaQuery : IRequest<StudentGpaDTO>
    {
        public int StudentID { get; set; }
        public GetStudentGpaQuery(int studentID)
        {
            StudentID = studentID;
        }
    }
}
