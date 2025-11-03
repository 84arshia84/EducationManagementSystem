using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ApplicationService.Dtos.Mentors
{
    public class MentorReadDto
    {
        public Guid UserId { get; set; }
        public string? Skills { get; set; }
        public string? ResumeUrl { get; set; }
        public bool IsMentorApproved { get; set; }

        // برای خروجی خلاصه کورس‌ها
        public List<string>? CourseTitles { get; set; }
    }
}
