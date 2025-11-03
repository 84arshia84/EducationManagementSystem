using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ApplicationService.Dtos.ClassroomMember
{
    public class UpdateClassroomMemberDto
    {
        //public RoleInClass? Role { get; set; }
        public bool? IsActive { get; set; }
        public DateTime? LeftAt { get; set; }
    }
}
