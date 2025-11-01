using ApplicationService.Dtos.Mentors;
using ApplicationService.ServicesContract.Mentor;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace EducationManagementSystem.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MentorsController : ControllerBase
    {
        private readonly IMentorService _service;

        public MentorsController(IMentorService service)
        {
            _service = service;
        }

        [HttpGet("GetAll")]
        public async Task<IActionResult> GetAll()
        {
            var mentors = await _service.GetAllAsync();
            return Ok(mentors);
        }

        [HttpGet("GetById{id}")]
        public async Task<IActionResult> GetById(Guid id)
        {
            var mentor = await _service.GetByIdAsync(id);
            if (mentor == null) return NotFound();
            return Ok(mentor);
        }

        [HttpPost("Create")]
        public async Task<IActionResult> Create(CreateMentorDto dto)
        {
            var created = await _service.CreateAsync(dto);
            return CreatedAtAction(nameof(GetById), new { id = created.Id }, created);
        }

        [HttpDelete("Delete{id}")]
        public async Task<IActionResult> Delete(Guid id)
        {
            await _service.DeleteAsync(id);
            return NoContent();
        }

        [HttpPut("Update{id}")]
        public async Task<IActionResult> Update(Guid id, UpdateMentorDto dto)
        {
            await _service.UpdateAsync(id, dto);
            return NoContent();
        }

        [HttpPut("UpdateMentorStatus{id}")]
        public async Task<IActionResult> Update(Guid id, UpdateMentorStatusDto  dto)
        {
            await _service.UpdateMentorStatusAsync(id, dto);
            return NoContent();
        }

    }
}
