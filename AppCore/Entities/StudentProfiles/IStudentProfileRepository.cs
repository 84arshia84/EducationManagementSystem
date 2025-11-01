using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AppCore.Entities.StudentProfiles
{
    public interface IStudentProfileRepository
    {
        Task<IEnumerable<StudentProfile>> GetAllAcync();
        Task <StudentProfile> GetByIdAcync(Guid id);
        Task DeleteByIdAcync(Guid id);
        Task AddAcync(StudentProfile studentProfile);
        Task UpdateAcync(StudentProfile studentProfile, Guid id);
    }
}
