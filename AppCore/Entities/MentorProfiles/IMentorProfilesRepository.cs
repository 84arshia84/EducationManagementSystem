using AppCore.Entities.Users;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AppCore.Entities.MentorProfiles
{
    public  interface IMentorProfilesRepository
    {
        Task <MentorProfile> GetByIdAsync (Guid Id);
        Task <IEnumerable<MentorProfile>> GetAllAsync ();
        Task AddAsync(MentorProfile mentorProfile);

        Task DeleteByIdAsync (Guid Id);
        Task UpdateAsync(MentorProfile mentorProfile, Guid id);
        Task UpdateMentorStatusAsync(Guid id, bool IsMentorApproved);


    }
}
