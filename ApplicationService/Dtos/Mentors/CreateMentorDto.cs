using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ApplicationService.Dtos.Mentors
{
    public class CreateMentorDto
    {
        public Guid UserId { get; set; }
        public string? Skills { get; set; }
        public string? ResumeUrl { get; set; }
    }
}
