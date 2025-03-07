using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using StudentManagement.Application.DTOs;
using StudentManagment.Application.CQRS.Queries;


namespace StudentManagment.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class StudentGPAController : ControllerBase
    {
        private readonly IMediator _mediator;
        public StudentGPAController(IMediator mediator)
        {
            _mediator = mediator;
        }

        // GET: /api/StudentGPA/{id}
        [HttpGet("{id}")]
        public async Task<ActionResult<StudentGpaDTO>> GetStudentGPA(int id)
        {
            var query = new GetStudentGpaQuery(id);
            var result = await _mediator.Send(query);
            if (result == null)
            {
                return NotFound(new { message = $"Student with id {id} not found!" });
            }
            return Ok(result);
        }

        // GET: api/StudentGPA/top3
        [HttpGet("top3")]
        public async Task<ActionResult<List<StudentGpaDTO>>> GetTop3Students()
        {
            var query = new GetTop3StudentsByGpaQuery();
            var result = await _mediator.Send(query);
            return Ok(result);
        }
    }
}
