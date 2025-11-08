using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ApplicationService.Dtos.Classroom
{
    public class UpdateClassroomDto
    {
        public string? Title { get; set; }
        public string? Description { get; set; }
        public DateTime? StartDate { get; set; }
        public bool? IsActive { get; set; }

        //public string? SharePointFolderUrl { get; set; }
    }
}
