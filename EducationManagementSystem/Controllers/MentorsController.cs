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
        public async Task<IActionResult> GetById(Guid userId)
        {
            var mentor = await _service.GetByIdAsync(userId);
            if (mentor == null) return NotFound();
            return Ok(mentor);
        }

        [HttpPost("Create")]
        public async Task<IActionResult> Create(CreateMentorDto dto)
        {
            var created = await _service.CreateAsync(dto);
            return CreatedAtAction(nameof(GetById), new { id = created.UserId }, created);
        }

        [HttpDelete("Delete{id}")]
        public async Task<IActionResult> Delete(Guid userId)
        {
            await _service.DeleteAsync(userId);
            return NoContent();
        }

        [HttpPut("Update")]
        public async Task<IActionResult> Update(Guid userId, UpdateMentorDto dto)
        {
            await _service.UpdateAsync(userId, dto);
            return NoContent();
        }

        [HttpPut("UpdateMentorStatus")]
        public async Task<IActionResult> Update(Guid userId, UpdateMentorStatusDto  dto)
        {
            await _service.UpdateMentorStatusAsync(userId, dto);
            return NoContent();
        }

    }
}
