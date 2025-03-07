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
    public class EnrollmentsController : ControllerBase
    {
        private readonly IMediator _mediator;
        public EnrollmentsController(IMediator mediator)
        {
            _mediator = mediator;
        }

        // GET: api/enrollments
        [HttpGet]
        public async Task<IActionResult> GetAllEnrollments()
        {
            var query = new GetAllEnrollmentsQuery();
            var enrollments = await _mediator.Send(query);
            return Ok(enrollments);
        }

        // GET: api/enrollment/{id}
        [HttpGet("{id}")]
        public async Task<IActionResult> GetEnrollmentById(int id)
        {
            var query = new GetEnrollmentByIdQuery(id);
            var enrollment = await _mediator.Send(query);
            if (enrollment == null)
            {
                return NotFound(new { message = "Enrollment data not found" });
            }
            return Ok(enrollment);
        }

        // POST: api/enrollment
        [HttpPost]
        public async Task<IActionResult> CreateEnrollment([FromBody] CreateEnrollmentCommand command)
        {
            var enrollment = await _mediator.Send(command);
            return CreatedAtAction(nameof(GetEnrollmentById), new { id = enrollment.EnrollmentID }, enrollment);
        }

        // PUT: api/enrollment/{id}
        [HttpPut("{id}")]
        public async Task<IActionResult> EnrollmentStudent(int id, [FromBody] UpdateEnrollmentCommand command)
        {
            if (id != command.EnrollmentID)
            {
                return BadRequest(new { message = "Mismatched Enrollment ID" });
            }

            await _mediator.Send(command);
            return Ok(new { message = "Enrollment updated successfully" });
        }

        // DELETE: api/enrollment/{id}
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteEnrollment(int id)
        {
            var command = new DeleteEnrollmentCommand(id);
            await _mediator.Send(command);
            return NoContent();
        }
    }
}
