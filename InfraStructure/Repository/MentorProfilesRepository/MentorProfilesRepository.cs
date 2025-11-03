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

        public async Task DeleteByIdAsync(Guid userId)
        {
            // FindAsync با مقدار کلید اصلی (UserId) کار می‌کند
            var mentor = await _context.MentorProfiles.FindAsync(userId);
            if (mentor == null) return;

            _context.MentorProfiles.Remove(mentor);
            await _context.SaveChangesAsync();
        }

        public async Task<IEnumerable<MentorProfile>> GetAllAsync()
        {
            return await _context.MentorProfiles.ToListAsync();
        }

        public async Task<MentorProfile?> GetByIdAsync(Guid userId)
        {
            // می‌توان از FindAsync هم استفاده کرد؛ اینجا FirstOrDefaultAsync برای شفافیت نوشته شده
            return await _context.MentorProfiles.FirstOrDefaultAsync(x => x.UserId == userId);
        }

        public async Task UpdateAsync(MentorProfile mentorProfile, Guid userId)
        {
            var existing = await _context.MentorProfiles.FindAsync(userId);
            if (existing == null) return;

            existing.Skills = mentorProfile.Skills;
            existing.ResumeUrl = mentorProfile.ResumeUrl;
            existing.IsMentorApproved = mentorProfile.IsMentorApproved;

            await _context.SaveChangesAsync();
        }

        public async Task UpdateMentorStatusAsync(Guid userId, bool isMentorApproved)
        {
            var existing = await _context.MentorProfiles.FindAsync(userId);
            if (existing == null) return;

            existing.IsMentorApproved = isMentorApproved;
            await _context.SaveChangesAsync();
        }
    }
}
