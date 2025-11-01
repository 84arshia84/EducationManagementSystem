using AppCore.UnitOfWork;
using ApplicationService.Dtos.User;
using ApplicationService.Mappers.Courses;
using ApplicationService.ServicesContract.User;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ApplicationService.Services.User
{
    public class UserService : IUserService
    {
        private readonly IUnitOfWork _uow;

        public UserService(IUnitOfWork uow)
        {
            _uow = uow;
        }

        public async Task<IEnumerable<UserReadDto>> GetAllAsync()
        {
            var users = await _uow.Users.GetAllAsync();
            return users.Select(UserMapper.ToDto);
        }

        public async Task<UserReadDto?> GetByIdAsync(Guid id)
        {
            var user = await _uow.Users.GetByIdAsync(id);
            return user == null ? null : UserMapper.ToDto(user);
        }

        public async Task<UserReadDto> CreateAsync(CreateUserDto dto)
        {
            var entity = UserMapper.ToEntity(dto);
            await _uow.Users.AddAsync(entity);
            await _uow.SaveChangesAsync();
            return UserMapper.ToDto(entity);
        }

        public async Task UpdateAsync(Guid id, UpdateUserDto dto)
        {
            var existing = await _uow.Users.GetByIdAsync(id);
            if (existing == null) return;

            UserMapper.UpdateEntity(existing, dto);
            await _uow.Users.UpdateAsync(existing, id);
            await _uow.SaveChangesAsync();
        }

        public async Task DeleteAsync(Guid id)
        {
            await _uow.Users.DeleteAsync(id);
            await _uow.SaveChangesAsync();
        }
    }
}
