using AppCore.Entities.Classroom;
using AppCore.Entities.ClassroomMember;
using AppCore.Entities.Courses;
using AppCore.Entities.MentorProfiles;
using AppCore.Entities.StudentProfiles;
using AppCore.Entities.Users;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AppCore.UnitOfWork
{
    public interface IUnitOfWork : IDisposable
    {
        IUserRepository Users { get; }
        ICourseRepository Courses { get; }
        IStudentProfileRepository Students { get; }
        IMentorProfilesRepository Mentors { get; }
        IClassroomMemberRepository ClassroomMembers { get; }
        IClassroomRepository Classrooms { get; }

        Task<int> SaveChangesAsync();
    }
}
