using AppCore.Entities.StudentProfiles;
using AppCore.Entities.Users;
using InfraStructure.DataBase;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InfraStructure.Repository.UserRepository
{
    public class UserRepository : IUserRepository
    {
        private readonly AppDbContext _context;
        public UserRepository(AppDbContext context)
        {
            _context = context;
        }

        public async Task AddAsync(User user)
        {
            await _context.Users.AddAsync(user);
            await _context.SaveChangesAsync();
        }

        public async Task DeleteAsync(Guid id)
        {
            var User = await _context.Users.FindAsync(id);
            if (User == null) return;
            {
                _context.Users.Remove(User);
                await _context.SaveChangesAsync();
            }
        }

        public async Task<IEnumerable<User>> GetAllAsync()
        {
            return await _context.Users.ToListAsync();
        }

        public async Task<User> GetByIdAsync(Guid id)
        {
            return await _context.Users.FirstOrDefaultAsync(x=>x.Id== id);
        }

        public async Task UpdateAsync(User user, Guid id)
        {
            var existing = await _context.Users.FindAsync(id);
            if (existing == null) return;

            existing.FirstName = user.FirstName;
            existing.LastName = user.LastName;
            existing.Email = user.Email;
            existing.PhoneNumber = user.PhoneNumber;
            existing.Role = user.Role;

            await _context.SaveChangesAsync();
        }
    }
}
