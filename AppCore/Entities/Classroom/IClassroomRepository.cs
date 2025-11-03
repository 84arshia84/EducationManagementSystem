using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AppCore.Entities.Classroom
{
    public interface IClassroomRepository
    {
        Task AddAsync (Classroom classroom);
        Task DeleteAsync (Guid id);
        Task<IEnumerable<Classroom>> GetAllAsync ();
        Task UpdateAsync (Classroom classroom,Guid id);
        Task <Classroom> GetByIdAsync (Guid id);

    }
}
