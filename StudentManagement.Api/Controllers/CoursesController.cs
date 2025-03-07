using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using StudentManagement.Application.CQRS.Commands;
using StudentManagment.Application.CQRS.Commands;
using StudentManagment.Application.CQRS.Queries;

namespace StudentManagment.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CoursesController : ControllerBase
    {
        private readonly IMediator _mediator;

        public CoursesController(IMediator mediator)
        {
            _mediator = mediator;
        }

        // GET: api/courses
        [HttpGet]
        public async Task<IActionResult> GetAllCourses()
        {
            var query = new GetAllCoursesQuery();
            var courses = await _mediator.Send(query);
            return Ok(courses);
        }

        // GET: api/courses/{id}
        [HttpGet("{id}")]
        public async Task<IActionResult> GetCourseById(int id)
        {
            var query = new GetCourseByIdQuery(id);
            var course = await _mediator.Send(query);
            if (course == null)
            {
                return NotFound(new { message = "Course not found" });
            }
            return Ok(course);
        }

        // POST: api/course
        [HttpPost]
        public async Task<IActionResult> CreateCourse([FromBody] CreateCourseCommand command)
        {
            var course = await _mediator.Send(command);
            return CreatedAtAction(nameof(GetCourseById), new { id = course.CourseID }, course);
        }

        // PUT: api/course/{id}
        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateCourse(int id, [FromBody] UpdateCourseCommand command)
        {
            if (id != command.CourseID)
            {
                return BadRequest(new { message = "Mismatched Course ID" });
            }

            await _mediator.Send(command);
            return Ok(new { message = "Course Updated Successfully" });
        }

        // DELETE: api/course/{id}
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteCourse(int id)
        {
            var command = new DeleteCourseCommand(id);
            await _mediator.Send(command);
            return NoContent();
        }
    }
}
