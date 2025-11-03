using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ApplicationService.Dtos.Classroom
{
    public class ClassroomDto
    {
        public Guid Id { get; set; }
        public string Title { get; set; } = default!;
        public string? Description { get; set; }
        public bool IsActive { get; set; }
        public Guid MentorId { get; set; }
        public string? MentorName { get; set; }
        public Guid? CourseId { get; set; }
        public string? CourseTitle { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime CreatedAt { get; set; }
        public DateTime? UpdatedAt { get; set; }

        public List<ClassroomStudentGetDto> Students { get; set; } = new();
    }
}
