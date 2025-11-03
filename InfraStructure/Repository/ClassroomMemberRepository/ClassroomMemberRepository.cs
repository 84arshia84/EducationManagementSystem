using AppCore.Entities.ClassroomMember;
using InfraStructure.DataBase;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InfraStructure.Repository.ClassroomMemberRepository
{
    public class ClassroomMemberRepository : IClassroomMemberRepository
    {
        private readonly AppDbContext _context;

        public ClassroomMemberRepository(AppDbContext context)
        {
            _context = context;
        }



        public async Task AddAsync(ClassroomMember member)
        {
            await _context.ClassroomMembers.AddAsync(member);
            await _context.SaveChangesAsync();
        }

        public async Task DeleteAsync(Guid id)
        {
            var existing = await _context.ClassroomMembers.FindAsync(id);
            if (existing == null) return;

            _context.ClassroomMembers.RemoveRange(existing);
            await _context.SaveChangesAsync();
        }

        public async Task<IEnumerable<ClassroomMember>> GetAllAsync()
        {
            return await _context.ClassroomMembers.ToListAsync();
        }

        public async Task<ClassroomMember> GetByIdAsync(Guid id)
        {
            return await _context.ClassroomMembers.FirstOrDefaultAsync(c => c.Id == id);
        }

        public async Task UpdateAsync(ClassroomMember member, Guid id)
        {
            _context.ClassroomMembers.Update(member);
            await _context.SaveChangesAsync();
        }
    }
}
