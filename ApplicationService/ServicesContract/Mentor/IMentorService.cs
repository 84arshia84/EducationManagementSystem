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
        Task<MentorReadDto?> GetByIdAsync(Guid id);
        Task<MentorReadDto> CreateAsync(CreateMentorDto dto);
        Task DeleteAsync(Guid id);
        Task UpdateAsync(Guid id, UpdateMentorDto dto);
        Task UpdateMentorStatusAsync (Guid id, UpdateMentorStatusDto dto);

    }
}
