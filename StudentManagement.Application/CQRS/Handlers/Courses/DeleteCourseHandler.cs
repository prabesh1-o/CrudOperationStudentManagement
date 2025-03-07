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
    public class DeleteCourseHandler : IRequestHandler<DeleteCourseCommand, Unit>
    {
        private readonly IRepository<Course> _repository;

        public DeleteCourseHandler(IRepository<Course> repository)
        {
            _repository = repository;
        }

        public async Task<Unit> Handle(DeleteCourseCommand request, CancellationToken cancellationToken)
        {
            await _repository.DeleteAsync(request.CourseID);
            return Unit.Value;
        }
    }
}
// HandCrafted By Rohan Thapa