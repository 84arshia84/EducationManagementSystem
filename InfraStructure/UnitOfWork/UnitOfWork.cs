using AppCore.Entities.Classroom;
using AppCore.Entities.ClassroomMember;
using AppCore.Entities.Courses;
using AppCore.Entities.MentorProfiles;
using AppCore.Entities.StudentProfiles;
using AppCore.Entities.Users;
using AppCore.UnitOfWork;
using InfraStructure.DataBase;
using InfraStructure.Repository.CourseRepository;

using InfraStructure.Repository.UserRepository;
using System;
using System.Threading.Tasks;

namespace InfraStructure.UnitOfWork
{
    public class UnitOfWork : IUnitOfWork, IDisposable
    {
        private readonly AppDbContext _db;

        public IUserRepository Users { get; }
        public ICourseRepository Courses { get; }
        public IStudentProfileRepository Students { get; }
        public IMentorProfilesRepository Mentors { get; }
        public IClassroomRepository Classrooms { get; }
        public IClassroomMemberRepository ClassroomMembers { get; }

        public UnitOfWork
            (
            AppDbContext db,
            IUserRepository userRepository,
            ICourseRepository courseRepository,
            IStudentProfileRepository studentRepository,
            IMentorProfilesRepository mentorRepository,
            IClassroomRepository classroomRepository,
            IClassroomMemberRepository classroomMemberRepository

            )
        {
            _db = db;

            Users = userRepository;
            Courses = courseRepository;
            Students = studentRepository;
            Mentors = mentorRepository;
            Mentors = mentorRepository;
            Classrooms = classroomRepository;
            ClassroomMembers = classroomMemberRepository;
        }

        public async Task<int> SaveChangesAsync()
        {
            return await _db.SaveChangesAsync();
        }

        public void Dispose()
        {
            _db.Dispose();
        }
    }
}
