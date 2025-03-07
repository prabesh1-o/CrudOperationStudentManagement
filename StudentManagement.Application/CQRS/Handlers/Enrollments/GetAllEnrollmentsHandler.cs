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
    public class GetAllEnrollmentsHandler : IRequestHandler<GetAllEnrollmentsQuery, List<EnrollmentDTO>>
    {
        private readonly IRepository<Enrollment> _repository;
        private readonly IMapper _mapper;

        public GetAllEnrollmentsHandler(IRepository<Enrollment> repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }
        public async Task<List<EnrollmentDTO>> Handle(GetAllEnrollmentsQuery request, CancellationToken cancellationToken)
        {
            var enrollments = await _repository.GetAllAsync();
            return _mapper.Map<List<EnrollmentDTO>>(enrollments);
        }
    }
}
