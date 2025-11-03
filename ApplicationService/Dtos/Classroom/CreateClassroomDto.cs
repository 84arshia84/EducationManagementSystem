using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ApplicationService.Dtos.Classroom
{
    public class CreateClassroomDto
    {
        public string Title { get; set; }
        public string? Description { get; set; }
        public Guid? CourseId { get; set; }
        public Guid MentorId { get; set; }     // REQUIRED
        public DateTime StartDate { get; set; }
        public DateTime? EndDate { get; set; }
        //public string? SharePointFolderUrl { get; set; }
    }
}
