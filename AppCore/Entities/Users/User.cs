using AppCore.Entities.MentorProfiles;
using AppCore.Entities.StudentProfiles;
using AppCore.Enums.Role;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AppCore.Entities.Users
{
    public class User
    {
        public Guid Id { get; set; }

        public string FirstName { get; set; }          
        public string LastName { get; set; }           
        public string Email { get; set; }              
        public string? PhoneNumber { get; set; }

        public Role Role { get; set; }                  // Admin / Mentor / Student

        public DateTime CreatedAt { get; set; } = DateTime.UtcNow;

        // روابط
        public StudentProfile? StudentProfile { get; set; }
        public MentorProfile? MentorProfile { get; set; }
    }
}
