using AppCore.Entities.Classroom;
using InfraStructure.DataBase;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InfraStructure.Repository.ClassroomRepository
{
    public class ClassroomRepository : IClassroomRepository
    {
        private readonly AppDbContext _context;

        public ClassroomRepository(AppDbContext context)
        {
            _context = context;
        }

        public async Task AddAsync(Classroom classroom)
        {
            await _context.Classrooms.AddAsync(classroom);
            await _context.SaveChangesAsync();
        }

        public async Task DeleteAsync(Guid id)
        {
            var existing = await _context.Classrooms.FindAsync(id);
            if (existing == null) return;
            _context.Classrooms.Remove(existing);
            await _context.SaveChangesAsync();
        }

        public async Task<IEnumerable<Classroom>> GetAllAsync()
        {
            return await _context.Classrooms.ToListAsync();
        }

        public async Task<Classroom> GetByIdAsync(Guid id)
        {
           return  await   _context.Classrooms.FirstOrDefaultAsync(c => c.Id == id);
        }

        public async Task UpdateAsync(Classroom classroom, Guid id)
        {
            _context.Classrooms.Update(classroom);
            await _context.SaveChangesAsync();
        }
    }
}
