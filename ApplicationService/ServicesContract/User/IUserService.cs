using ApplicationService.Dtos.Courses;
using ApplicationService.Dtos.User;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ApplicationService.ServicesContract.User
{
    public  interface IUserService
    {
        Task DeleteAsync(Guid ID);
        Task UpdateAsync(Guid ID  , UpdateUserDto dto);
        Task<IEnumerable<UserReadDto>> GetAllAsync();
        Task<UserReadDto?> GetByIdAsync(Guid id);
        Task<UserReadDto> CreateAsync(CreateUserDto dto);
    }
}
