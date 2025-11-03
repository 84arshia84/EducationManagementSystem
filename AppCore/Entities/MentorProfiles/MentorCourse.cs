using AppCore.Entities.Courses;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AppCore.Entities.MentorProfiles
{
    public class MentorCourse
    {
        public Guid Id { get; set; }

        public Guid MentorUserId { get; set; }
        public Guid CourseId { get; set; }

        public DateTime AssignedAt { get; set; } = DateTime.UtcNow;

        // روابط
        public MentorProfile MentorProfile { get; set; }
        public Course Course { get; set; }
    }
}
