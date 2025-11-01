using AppCore.Entities.Users;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AppCore.Entities.MentorProfiles
{
    public class MentorProfile
    {
        public Guid Id { get; set; }
        public Guid UserId { get; set; }

        public string? Skills { get; set; }
        public string? ResumeUrl { get; set; }
        public bool IsMentorApproved { get; set; } = false;

        public User User { get; set; }

        public ICollection<MentorCourse> MentorCourses { get; set; }
    }
}
