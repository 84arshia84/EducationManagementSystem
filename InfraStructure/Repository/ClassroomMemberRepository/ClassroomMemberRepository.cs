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



        public async Task<IEnumerable<ClassroomMember>> GetAllAsync()
        {
            return await _context.ClassroomMembers
                .Include(cm => cm.User)
                .Include(cm => cm.Classroom)
                .ToListAsync();
        }

        // گرفتن عضو خاص با اطلاعات مرتبط
        public async Task<ClassroomMember?> GetByIdAsync(Guid id)
        {
            return await _context.ClassroomMembers
                .Include(cm => cm.User)
                .Include(cm => cm.Classroom)
                .FirstOrDefaultAsync(c => c.Id == id);
        }

        // اضافه کردن عضو جدید
        public async Task AddAsync(ClassroomMember entity)
        {
            await _context.ClassroomMembers.AddAsync(entity);
            // توجه: SaveChangesAsync در UnitOfWork صدا زده می‌شود
        }

        // به‌روزرسانی عضو
        public async Task UpdateAsync(ClassroomMember entity , Guid id)
        {
            _context.ClassroomMembers.Update(entity);
            await Task.CompletedTask;
        }

        // حذف عضو
        public async Task DeleteAsync(Guid id)
        {
            var existing = await _context.ClassroomMembers.FindAsync(id);
            if (existing != null)
            {
                _context.ClassroomMembers.Remove(existing);
            }
        }

    }
}
