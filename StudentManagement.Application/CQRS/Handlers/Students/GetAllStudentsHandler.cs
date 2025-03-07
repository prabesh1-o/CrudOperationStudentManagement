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

namespace StudentManagment.Application.CQRS.Handlers.Students
{
    public class GetAllStudentsHandler : IRequestHandler<GetAllStudentsQuery, List<StudentDTO>>
    {
        private readonly IRepository<Student> _repository;
        private readonly IMapper _mapper;

        public GetAllStudentsHandler(IRepository<Student> repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        public async Task<List<StudentDTO>> Handle(GetAllStudentsQuery request, CancellationToken cancellationToken)
        {
            var students = await _repository.GetAllAsync();
            return _mapper.Map<List<StudentDTO>>(students);
        }
    }
}
