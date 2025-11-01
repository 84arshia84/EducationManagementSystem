using AppCore.Entities.Courses;
using AppCore.Entities.MentorProfiles;
using AppCore.Entities.StudentProfiles;
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
        public Guid StudentId { get; set; }
        public Guid MentorId { get; set; }
        public Guid CourseId { get; set; }
        public ICollection<Course> Courses { get; set; }
        public ICollection<StudentProfile> StudentProfile { get; set; }


    }
}
