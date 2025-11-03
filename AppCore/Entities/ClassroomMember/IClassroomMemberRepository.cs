using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AppCore.Entities.ClassroomMember
{
    public interface IClassroomMemberRepository
    {
        Task AddAsync(ClassroomMember member);
        Task UpdateAsync(ClassroomMember member,Guid id);
        Task <IEnumerable<ClassroomMember>> GetAllAsync();
        Task <ClassroomMember> GetByIdAsync(Guid id);
        Task DeleteAsync(Guid id);

    }
}
