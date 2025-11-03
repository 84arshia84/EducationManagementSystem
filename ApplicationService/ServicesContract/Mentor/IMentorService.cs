using ApplicationService.Dtos.Mentors;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ApplicationService.ServicesContract.Mentor
{
    public interface IMentorService
    {
        Task<IEnumerable<MentorReadDto>> GetAllAsync();
        Task<MentorReadDto?> GetByIdAsync(Guid userId);
        Task<MentorReadDto> CreateAsync(CreateMentorDto dto);
        Task DeleteAsync(Guid userId);
        Task UpdateAsync(Guid userId, UpdateMentorDto dto);
        Task UpdateMentorStatusAsync (Guid userId, UpdateMentorStatusDto dto);

    }
}
