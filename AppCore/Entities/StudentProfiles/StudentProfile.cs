using AppCore.Entities.Users;
using AppCore.Enums.StudentLevel;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AppCore.Entities.StudentProfiles
{
    public class StudentProfile
    {
        [Key]
        public Guid UserId { get; set; }

        public string? Skills { get; set; }
        public string? Languages { get; set; }

        public StudentLevel Level { get; set; } = StudentLevel.Beginner;
        public double Progress { get; set; } = 0;

        public User User { get; set; }

        public ICollection<StudentCourse> StudentCourses { get; set; }
    }
}
