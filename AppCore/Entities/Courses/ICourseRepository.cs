using AppCore.Entities.StudentProfiles;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AppCore.Entities.Courses
{
    public interface ICourseRepository
    {
        Task<IEnumerable<Course>> GetAllAsync();
        Task<Course?> GetByIdAsync(Guid id);
        Task AddAsync(Course course);
        Task UpdateAsync(Course entity, Guid id);
        Task DeleteByIdAsync(Guid id);
    }
}
