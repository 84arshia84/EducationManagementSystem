using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ApplicationService.Dtos.ClassroomMember
{
    public class ClassroomMemberDto
    {
        public Guid Id { get; set; }
        public Guid UserId { get; set; }
        public string FullName { get; set; } = default!;
        public string? Email { get; set; }
        public Guid ClassroomId { get; set; }
        public string ClassroomTitle { get; set; } = default!;
        public bool IsActive { get; set; }
        public DateTime JoinedAt { get; set; }

    }
}
