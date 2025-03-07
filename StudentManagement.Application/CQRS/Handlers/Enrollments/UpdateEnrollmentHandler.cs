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

namespace StudentManagment.Application.CQRS.Handlers.Enrollments
{
    public class UpdateEnrollmentHandler : IRequestHandler<UpdateEnrollmentCommand, Unit>
    {
        private readonly IRepository<Enrollment> _repository;
        private readonly IMapper _mapper;
        public UpdateEnrollmentHandler(IRepository<Enrollment> repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }
        public async Task<Unit> Handle(UpdateEnrollmentCommand request, CancellationToken cancellationToken)
        {
            var enrollment = await _repository.GetByIdAsync(request.EnrollmentID);
            if (enrollment == null)
            {
                throw new KeyNotFoundException("Enrollment not found");
            }

            enrollment.StudentID = request.StudentID;
            enrollment.CourseID = request.CourseID;
            enrollment.EnrollmentDate = request.EnrollmentDate;

            await _repository.UpdateAsync(enrollment);
            return Unit.Value;
        }
    }
}
