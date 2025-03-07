using AutoMapper;
using MediatR;
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
    public class UpdateStudentHandler : IRequestHandler<UpdateStudentCommand, Unit>
    {
        private readonly IRepository<Student> _repository;
        private readonly IMapper _mapper;

        public UpdateStudentHandler(IRepository<Student> repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        public async Task<Unit> Handle(UpdateStudentCommand request, CancellationToken cancellationToken)
        {
            var student = await _repository.GetByIdAsync(request.StudentID);
            if (student == null)
            {
                throw new KeyNotFoundException("Student not found");
            }

            student.FullName = request.FullName;
            student.Email = request.Email;
            student.PhoneNumber = request.PhoneNumber;

            await _repository.UpdateAsync(student);
            return Unit.Value; // Return Unit.Value instead of just Task
        }
    }
}
