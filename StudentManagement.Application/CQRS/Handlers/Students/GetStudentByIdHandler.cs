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
    public class GetStudentByIdHandler : IRequestHandler<GetStudentByIdQuery, StudentDTO>
    {
        private readonly IRepository<Student> _repository;
        private readonly IMapper _mapper;

        public GetStudentByIdHandler(IRepository<Student> repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        public async Task<StudentDTO> Handle(GetStudentByIdQuery request, CancellationToken cancellationToken)
        {
            var student = await _repository.GetByIdAsync(request.StudentID);
            if (student == null)
            {
                throw new KeyNotFoundException("Student not found");
            }
            return _mapper.Map<StudentDTO>(student);
        }
    }

}
