using AutoMapper;
using MediatR;
using StudentManagement.Application.DTOs;
using StudentManagement.Core.Entity;
using StudentManagment.Application.CQRS.Commands;

using StudentManagment.Core.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StudentManagment.Application.CQRS.Handlers.Students
{
    public class CreateStudentHandler : IRequestHandler<CreateStudentCommand, StudentDTO>
    {
        private readonly IRepository<Student> _repository;
        private readonly IMapper _mapper;

        public CreateStudentHandler(IRepository<Student> repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        public async Task<StudentDTO> Handle(CreateStudentCommand request, CancellationToken cancellationToken)
        {
            var student = new Student
            {
                FullName = request.FullName,
                Email = request.Email,
                PhoneNumber = request.PhoneNumber,
                RegistrationDate = DateTime.UtcNow
            };

            await _repository.AddAsync(student);
            return _mapper.Map<StudentDTO>(student);
        }
    }

}
