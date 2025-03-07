using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using StudentManagment.Application.CQRS.Commands;
using StudentManagment.Application.CQRS.Queries;

namespace StudentManagment.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class GradesController : ControllerBase
    {
        private readonly IMediator _mediator;
        public GradesController(IMediator mediator)
        {
            _mediator = mediator;
        }

        // GET: api/grades
        [HttpGet]
        public async Task<IActionResult> GetAllGrades()
        {
            var query = new GetAllGradesQuery();
            var grades = await _mediator.Send(query);
            return Ok(grades);
        }

        // GET: api/grade/{id}
        [HttpGet("{id}")]
        public async Task<IActionResult> GetGradeById(int id)
        {
            var query = new GetGradeByIdQuery(id);
            var grade = await _mediator.Send(query);
            if (grade == null)
            {
                return NotFound(new { message = "Grade data not found" });
            }
            return Ok(grade);
        }

        // POST: api/grade
        [HttpPost]
        public async Task<IActionResult> CreateGrade([FromBody] CreateGradeCommand command)
        {
            var grade = await _mediator.Send(command);
            return CreatedAtAction(nameof(GetGradeById), new { id = grade.GradeID }, grade);
        }

        // PUT: api/grade/{id}
        [HttpPut("{id}")]
        public async Task<IActionResult> GradeStudent(int id, [FromBody] UpdateGradeCommand command)
        {
            if (id != command.GradeID)
            {
                return BadRequest(new { message = "Mismatched Grade ID" });
            }

            await _mediator.Send(command);
            return Ok(new { message = "Grade updated successfully" });
        }

        // DELETE: api/grade/{id}
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteGrade(int id)
        {
            var command = new DeleteGradeCommand(id);
            await _mediator.Send(command);
            return NoContent();
        }
    }
}
