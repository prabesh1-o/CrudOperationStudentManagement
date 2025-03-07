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
    public class GetAllGradesHandler : IRequestHandler<GetAllGradesQuery, List<GradeDTO>>
    {
        private readonly IRepository<Grade> _repository;
        private readonly IMapper _mapper;

        public GetAllGradesHandler(IRepository<Grade> repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }
        public async Task<List<GradeDTO>> Handle(GetAllGradesQuery request, CancellationToken cancellationToken)
        {
            var grades = await _repository.GetAllAsync();
            return _mapper.Map<List<GradeDTO>>(grades);
        }
    }
}
