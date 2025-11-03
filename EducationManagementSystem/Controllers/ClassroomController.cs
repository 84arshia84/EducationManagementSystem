using ApplicationService.Dtos.Classroom;
using ApplicationService.ServicesContract.Classroom;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace EducationManagementSystem.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ClassroomsController : ControllerBase
    {
        private readonly IClassroomService _service;

        public ClassroomsController(IClassroomService service)
        {
            _service = service;
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var classrooms = await _service.GetAllAsync();
            return Ok(classrooms);
        }

            [HttpGet("{id:guid}")]
        public async Task<IActionResult> GetById(Guid id)
        {
            var classroom = await _service.GetByIdAsync(id);
            if (classroom == null)
                return NotFound($"Classroom with ID {id} not found.");

            return Ok(classroom);
        }

        [HttpPost]
        public async Task<IActionResult> Create([FromBody] CreateClassroomDto dto)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var created = await _service.CreateAsync(dto);
            return CreatedAtAction(nameof(GetById), new { id = created.Id }, created);
        }

        [HttpPut("{id:guid}")]
        public async Task<IActionResult> Update(Guid id, [FromBody] UpdateClassroomDto dto)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            await _service.UpdateAsync(id, dto);
            return NoContent();
        }

        [HttpDelete("{id:guid}")]
        public async Task<IActionResult> Delete(Guid id)
        {
            await _service.DeleteAsync(id);
            return NoContent();
        }
    }
}
