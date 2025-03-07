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

namespace StudentManagment.Application.CQRS.Handlers.Enrollments
{
    public class GetEnrollmentByIdHandler : IRequestHandler<GetEnrollmentByIdQuery, EnrollmentDTO>
    {
        private readonly IRepository<Enrollment> _repository;
        private readonly IMapper _mapper;

        public GetEnrollmentByIdHandler(IRepository<Enrollment> repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }
        public async Task<EnrollmentDTO> Handle(GetEnrollmentByIdQuery request, CancellationToken cancellationToken)
        {
            var enrollment = await _repository.GetByIdAsync(request.EnrollmentID);
            if (enrollment == null)
            {
                throw new KeyNotFoundException("Enrollment not found");
            }
            return _mapper.Map<EnrollmentDTO>(enrollment);
        }
    }
}
