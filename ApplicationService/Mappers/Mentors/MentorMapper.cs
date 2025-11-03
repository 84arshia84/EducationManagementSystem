using AppCore.Entities.MentorProfiles;
using ApplicationService.Dtos.Mentors;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ApplicationService.Mappers.Mentors
{
    public static class MentorMapper
    {
        public static MentorReadDto ToDto(MentorProfile mentor)
        {
            return new MentorReadDto
            {
                UserId = mentor.UserId,
                Skills = mentor.Skills,
                ResumeUrl = mentor.ResumeUrl,
                IsMentorApproved = mentor.IsMentorApproved,
                CourseTitles = mentor.MentorCourses?
                    .Select(mc => mc.Course.Title)
                    .ToList()
            };
        }

        public static MentorProfile ToEntity(CreateMentorDto dto)
        {
            return new MentorProfile
            {
                UserId = dto.UserId,
                Skills = dto.Skills,
                ResumeUrl = dto.ResumeUrl
            };
        }

        public static void UpdateEntity(MentorProfile mentor, UpdateMentorDto dto)
        {
            mentor.Skills = dto.Skills;
            mentor.ResumeUrl = dto.ResumeUrl;
            mentor.IsMentorApproved = dto.IsMentorApproved;
        }
        //public static void UpdateMentorStatusEntity(bool IsMentorApproved, UpdateMentorStatusDto dto) 
        //{
        //    IsMentorApproved &= dto.IsMentorApproved;
        //}
    }
}
