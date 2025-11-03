using ApplicationService.Dtos.Classroom;
using ApplicationService.Dtos.ClassroomMember;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ApplicationService.ServicesContract.ClassroomMember
{
    public interface IClassroomMemberService
    {
        Task<IEnumerable<ClassroomMemberDto>> GetAllAsync();
        Task<ClassroomMemberDto?> GetByIdAsync(Guid id);
        Task<ClassroomMemberDto> CreateAsync(CreateClassroomMemberDto dto);
        Task UpdateAsync(Guid id, UpdateClassroomMemberDto dto);
        Task DeleteAsync(Guid id);
    }
}
