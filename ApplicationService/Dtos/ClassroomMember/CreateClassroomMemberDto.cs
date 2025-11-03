using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ApplicationService.Dtos.ClassroomMember
{
    public class CreateClassroomMemberDto
    {
        public Guid UserId { get; set; }         // کاربر اضافه‌شونده
        public Guid ClassroomId { get; set; }


    }
}
