﻿using MediatR;
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
    public class DeleteEnrollmentHandler : IRequestHandler<DeleteEnrollmentCommand, Unit>
    {
        private readonly IRepository<Enrollment> _repository;

        public DeleteEnrollmentHandler(IRepository<Enrollment> repository)
        {
            _repository = repository;
        }
        public async Task<Unit> Handle(DeleteEnrollmentCommand request, CancellationToken cancellationToken)
        {
            await _repository.DeleteAsync(request.EnrollmentID);
            return Unit.Value;
        }
    }
}
