using ApplicationService.Dtos.Classroom;
using ApplicationService.Dtos.Courses;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ApplicationService.ServicesContract.Classroom
{
    public interface IClassroomService
    {
        Task<IEnumerable<ClassroomDto>> GetAllAsync();
        Task<ClassroomDto?> GetByIdAsync(Guid id);
        Task<ClassroomDto> CreateAsync(CreateClassroomDto dto);
        Task UpdateAsync(Guid id, UpdateClassroomDto dto);
        Task DeleteAsync(Guid id);
    }
}
