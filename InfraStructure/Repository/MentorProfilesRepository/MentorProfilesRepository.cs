using AppCore.Entities.MentorProfiles;
using InfraStructure.DataBase;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InfraStructure.Repository.MentorProfilesRepository
{
    public class MentorProfilesRepository : IMentorProfilesRepository
    {
        private readonly AppDbContext _context;

        public MentorProfilesRepository(AppDbContext context)
        {
            _context = context;
        }

        public async Task AddAsync(MentorProfile mentorProfile)
        {
            await _context.MentorProfiles.AddAsync(mentorProfile);
            await _context.SaveChangesAsync();
        }

        public async Task DeleteByIdAsync(Guid Id)
        {
            var Mentor = await _context.MentorProfiles.FindAsync(Id);
            if (Mentor == null) return;
            {
                _context.MentorProfiles.Remove(Mentor);
                await _context.SaveChangesAsync();
            }

        }

        public async Task<IEnumerable<MentorProfile>> GetAllAsync()
        {
            return await _context.MentorProfiles.ToListAsync();
        }

        public async Task<MentorProfile> GetByIdAsync(Guid Id)
        {
            return await _context.MentorProfiles.FirstOrDefaultAsync(x => x.Id == Id);

        }

        public async Task UpdateAsync(MentorProfile mentorProfile, Guid id)
        {
            var existing = await _context.MentorProfiles.FindAsync(id);
            if (existing == null) return;

            existing.Skills = mentorProfile.Skills;
            existing.ResumeUrl = mentorProfile.ResumeUrl;
            existing.IsMentorApproved = mentorProfile.IsMentorApproved;

            await _context.SaveChangesAsync();
        }

        public async Task UpdateMentorStatusAsync(Guid id, bool IsMentorApproved)
        {
            var existing = await _context.MentorProfiles.FindAsync(id);
            if (existing == null) return;
            existing.IsMentorApproved = IsMentorApproved ;
        }
    }
}
