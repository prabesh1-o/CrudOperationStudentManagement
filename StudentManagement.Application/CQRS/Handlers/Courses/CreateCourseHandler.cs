using AutoMapper;
using MediatR;
using StudentManagement.Application.CQRS.Commands;
using StudentManagement.Application.DTOs;
using StudentManagement.Core.Entity;
using StudentManagment.Application.CQRS.Commands;
using StudentManagment.Core.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StudentManagment.Application.CQRS.Handlers.Courses
{
    public class CreateCourseHandler : IRequestHandler<CreateCourseCommand, CourseDTO>
    {
        private readonly IRepository<Course> _repository;
        private readonly IMapper _mapper;

        public CreateCourseHandler(IRepository<Course> repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }
        public async Task<CourseDTO> Handle(CreateCourseCommand request, CancellationToken cancellationToken)
        {
            var course = new Course
            {
                CourseName = request.CourseName,
                CourseCode = request.CourseCode,
                CreditHours = request.CreditHours
            };

            await _repository.AddAsync(course);
            return _mapper.Map<CourseDTO>(course);
        }
    }
}
