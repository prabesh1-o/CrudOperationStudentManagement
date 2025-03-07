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

namespace StudentManagment.Application.CQRS.Handlers.Courses
{
    public class UpdateCourseHandler : IRequestHandler<UpdateCourseCommand, Unit>
    {
        private readonly IRepository<Course> _repository;
        private readonly IMapper _mapper;

        public UpdateCourseHandler(IRepository<Course> repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }
        public async Task<Unit> Handle(UpdateCourseCommand request, CancellationToken cancellationToken)
        {
            var course = await _repository.GetByIdAsync(request.CourseID);
            if (course == null)
            {
                throw new KeyNotFoundException("Course Not Found!");
            }

            course.CourseName = request.CourseName;
            course.CourseCode = request.CourseCode;
            course.CreditHours = request.CreditHours;

            await _repository.UpdateAsync(course);
            return Unit.Value;
        }
    }
}
