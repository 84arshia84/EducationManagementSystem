using AppCore.Entities.Courses;
using AppCore.Entities.MentorProfiles;
using AppCore.Entities.StudentProfiles;
using AppCore.Entities.Users;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AppCore.Entities.Classroom
{
    public class Classroom
    {
        public Guid Id { get; set; }
        public string Title { get; set; }
        public string? Description { get; set; }
        //public string? SharePointFolderUrl { get; set; }
        public bool IsActive { get; set; } = true;
        public Guid MentorId { get; set; }
        public Guid? CourseId { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime CreatedAt { get; set; } = DateTime.UtcNow;
        public DateTime? UpdatedAt { get; set; }



        public User Mentor { get; set; }
        public Course? Course { get; set; }

        public ICollection<ClassroomMember.ClassroomMember> Members { get; set; } = new List<ClassroomMember.ClassroomMember>();


    }
}
