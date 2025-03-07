using MediatR;
using Microsoft.AspNetCore.Mvc;
using StudentManagment.Application.CQRS.Commands;
using StudentManagment.Application.CQRS.Queries;
using System.Threading.Tasks;

namespace StudentManagment.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class StudentController : ControllerBase
    {
        private readonly IMediator _mediator;

        public StudentController(IMediator mediator)
        {
            _mediator = mediator;
        }

        // GET: api/students
        [HttpGet]
        public async Task<IActionResult> GetAllStudents()
        {
            var query = new GetAllStudentsQuery();
            var students = await _mediator.Send(query);
            return Ok(students);
        }

        // GET: api/student/{id}
        [HttpGet("{id}")]
        public async Task<IActionResult> GetStudentById(int id)
        {
            var query = new GetStudentByIdQuery(id);
            var student = await _mediator.Send(query);
            if (student == null)
            {
                return NotFound(new { message = "Student not found" });
            }
            return Ok(student);
        }

        // POST: api/student
        [HttpPost]
        public async Task<IActionResult> CreateStudent([FromBody] CreateStudentCommand command)
        {
            var student = await _mediator.Send(command);
            return CreatedAtAction(nameof(GetStudentById), new { id = student.StudentID }, student);
        }

        // PUT: api/student/{id}
        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateStudent(int id, [FromBody] UpdateStudentCommand command)
        {
            if (id != command.StudentID)
            {
                return BadRequest(new { message = "Mismatched Student ID" });
            }

            await _mediator.Send(command);
            return Ok(new { message = "Student updated successfully" });
        }

        // DELETE: api/student/{id}
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteStudent(int id)
        {
            var command = new DeleteStudentCommand(id);
            await _mediator.Send(command);
            return NoContent();
        }
    }
}
