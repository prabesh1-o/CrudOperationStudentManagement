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

namespace StudentManagment.Application.CQRS.Handlers.Courses
{
    public class GetAllCoursesHandler : IRequestHandler<GetAllCoursesQuery, List<CourseDTO>>
    {
        private readonly IRepository<Course> _repository;
        private readonly IMapper _mapper;

        public GetAllCoursesHandler(IRepository<Course> repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }
        public async Task<List<CourseDTO>> Handle(GetAllCoursesQuery request, CancellationToken cancellationToken)
        {
            var courses = await _repository.GetAllAsync();
            return _mapper.Map<List<CourseDTO>>(courses);
        }
    }
}
