using AppCore.Entities.MentorProfiles;
using AppCore.Entities.StudentProfiles;
using AppCore.Entities.Users;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AppCore.Entities.Courses
{
    public class Course
    {
        public Guid Id { get; set; }


        public string Title { get; set; }
        public string? Description { get; set; }


        public DateTime CreatedAt { get; set; } = DateTime.UtcNow;

        public ICollection<MentorCourse> MentorCourses { get; set; }
        public ICollection<StudentCourse> StudentCourses { get; set; }

        public ICollection<Classroom.Classroom> Classrooms { get; set; } = new List<Classroom.Classroom>();

    }

}
