using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ApplicationService.Dtos.Classroom
{
    public class ClassroomStudentGetDto
    {
        public Guid UserId { get; set; }
        public string FullName { get; set; } = default!;
        public string? Email { get; set; }
        public DateTime JoinedAt { get; set; }
        public bool IsActive { get; set; }
    }
}
