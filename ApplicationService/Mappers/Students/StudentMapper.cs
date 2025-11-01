using AppCore.Entities.StudentProfiles;
using ApplicationService.Dtos.Students;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ApplicationService.Mappers.Students
{
    public static class StudentMapper
    {
        public static StudentReadDto ToDto(StudentProfile student)
        {
            return new StudentReadDto
            {
                Id = student.Id,
                UserId = student.UserId,
                Skills = student.Skills,
                Languages = student.Languages,
                Level = student.Level,
                Progress = student.Progress,
                CourseTitles = student.StudentCourses?
                    .Select(sc => sc.Course.Title)
                    .ToList()
            };
        }

        public static StudentProfile ToEntity(CreateStudentDto dto)
        {
            return new StudentProfile
            {
                UserId = dto.UserId,
                Skills = dto.Skills,
                Languages = dto.Languages,
                Level = dto.Level
            };
        }

        public static void UpdateEntity(StudentProfile student, UpdateStudentDto dto)
        {
            student.Skills = dto.Skills;
            student.Languages = dto.Languages;
            student.Level = dto.Level;
            student.Progress = dto.Progress;
        }
    }
}
