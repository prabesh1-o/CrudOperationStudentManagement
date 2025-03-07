using MediatR;
using StudentManagement.Application.DTOs;

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StudentManagment.Application.CQRS.Queries
{
    public record GetGradeByIdQuery(int GradeID) : IRequest<GradeDTO>;
}
