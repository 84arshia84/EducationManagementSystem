using ApplicationService.Dtos.Students;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ApplicationService.ServicesContract.Student
{
    public interface IStudentService
    {
        Task<IEnumerable<StudentReadDto>> GetAllAsync();
        Task<StudentReadDto?> GetByIdAsync(Guid id);
        Task<StudentReadDto> CreateAsync(CreateStudentDto dto);
        Task UpdateAsync(Guid id, UpdateStudentDto dto);
        Task DeleteAsync(Guid id);
    }
}
