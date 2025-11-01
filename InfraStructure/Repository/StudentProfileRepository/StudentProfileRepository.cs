using AppCore.Entities.MentorProfiles;
using AppCore.Entities.StudentProfiles;
using InfraStructure.DataBase;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InfraStructure.Repository.StudentProfileRepository
{
    public class StudentProfileRepository : IStudentProfileRepository
    {

        private readonly AppDbContext _context;

        public StudentProfileRepository(AppDbContext context)
        {
            _context = context;
        }

        public async Task AddAcync(StudentProfile studentProfile)
        {
            await _context.StudentProfiles.AddAsync(studentProfile);
            await _context.SaveChangesAsync();
        }

        public async Task DeleteByIdAcync(Guid id)
        {
            var Student = await _context.StudentProfiles.FindAsync(id);
            if (Student == null) return;
            {
                _context.StudentProfiles.Remove(Student);
                await _context.SaveChangesAsync();
            }
        }

        public async Task<IEnumerable<StudentProfile>> GetAllAcync()
        {
            return await _context.StudentProfiles.ToListAsync();
        }

        public async Task<StudentProfile> GetByIdAcync(Guid id)
        {
            return await _context.StudentProfiles.FirstOrDefaultAsync(x => x.Id == id);
        }


        public async Task UpdateAcync(StudentProfile studentProfile, Guid id)
        {
            var existing = await _context.StudentProfiles.FindAsync(id);
            if (existing == null) return;

            existing.Skills = studentProfile.Skills;
            existing.Languages = studentProfile.Languages;
            existing.Level = studentProfile.Level;
            existing.Progress = studentProfile.Progress;

            await _context.SaveChangesAsync();
        }
    }
}
