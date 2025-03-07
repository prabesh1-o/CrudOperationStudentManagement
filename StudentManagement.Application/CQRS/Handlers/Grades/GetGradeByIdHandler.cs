using AutoMapper;
using MediatR;
using StudentManagement.Application.DTOs;
using StudentManagement.Core.Entity;
using StudentManagment.Application.CQRS.Queries;

using StudentManagment.Core.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StudentManagment.Application.CQRS.Handlers.Grades
{
    public class GetGradeByIdHandler : IRequestHandler<GetGradeByIdQuery, GradeDTO>
    {
        private readonly IRepository<Grade> _repository;
        private readonly IMapper _mapper;

        public GetGradeByIdHandler(IRepository<Grade> repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }
        public async Task<GradeDTO> Handle(GetGradeByIdQuery request, CancellationToken cancellationToken)
        {
            var grade = await _repository.GetByIdAsync(request.GradeID);
            if (grade == null)
            {
                throw new KeyNotFoundException("Grade Not Found!!!");
            }
            return _mapper.Map<GradeDTO>(grade);
        }
    }
}
