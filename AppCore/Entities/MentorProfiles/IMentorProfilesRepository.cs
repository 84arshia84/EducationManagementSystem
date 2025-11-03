using AppCore.Entities.Users;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AppCore.Entities.MentorProfiles
{
    public interface IMentorProfilesRepository
    {
        Task<MentorProfile?> GetByIdAsync(Guid userId);
        Task<IEnumerable<MentorProfile>> GetAllAsync();
        Task AddAsync(MentorProfile mentorProfile);

        Task DeleteByIdAsync(Guid userId);
        Task UpdateAsync(MentorProfile mentorProfile, Guid userId);
        Task UpdateMentorStatusAsync(Guid userId, bool IsMentorApproved);

    }
}
