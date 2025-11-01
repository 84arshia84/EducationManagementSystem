using AppCore.Entities.Courses;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AppCore.Entities.StudentProfiles
{
    public class StudentCourse
    {
        public Guid Id { get; set; }

        public Guid StudentProfileId { get; set; }
        public Guid CourseId { get; set; }

        public DateTime EnrolledAt { get; set; } = DateTime.UtcNow;
        public double Progress { get; set; } = 0; // درصد پیشرفت در این کورس

        public double? Score { get; set; } // نمره نهایی (اختیاری)

        // روابط
        public StudentProfile StudentProfile { get; set; }
        public Course Course { get; set; }
    }
}
