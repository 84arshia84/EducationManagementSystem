using AppCore.Entities.Users;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AppCore.Entities.ClassroomMember
{
    public class ClassroomMember
    {
        public Guid Id { get; set; }
        public DateTime JoinedAt { get; set; } = DateTime.UtcNow;
        public bool IsActive { get; set; } = true;


        public Guid UserId { get; set; }
        public Guid ClassroomId { get; set; }


        public User User { get; set; }
        public Classroom.Classroom Classroom { get; set; }
          
        
        //public bool IsInstructor { get; set; } = false;

    }
}
