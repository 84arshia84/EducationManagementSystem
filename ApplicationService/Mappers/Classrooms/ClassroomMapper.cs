using AppCore.Entities.Classroom;
using ApplicationService.Dtos.Classroom;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ApplicationService.Mappers.Classrooms
{
    public static class ClassroomMapper
    {
        public static ClassroomDto ToDto(Classroom classroom)
        {
            return new ClassroomDto
            {
                Id = classroom.Id,
                Title = classroom.Title,
                Description = classroom.Description,
                IsActive = classroom.IsActive,
                MentorId = classroom.MentorId,
                MentorName = classroom.Mentor != null? $"{classroom.Mentor.FirstName} {classroom.Mentor.LastName}": null,
                CourseId = classroom.CourseId,
                CourseTitle = classroom.Course?.Title,
                StartDate = classroom.StartDate,
                CreatedAt = classroom.CreatedAt,
                UpdatedAt = classroom.UpdatedAt,
                Students = classroom.Members?
                    .Select(m => new ClassroomStudentGetDto
                    {
                        UserId = m.UserId,
                        FullName = $"{m.User.FirstName} {m.User.LastName}",
                        Email = m.User.Email,
                        JoinedAt = m.JoinedAt,
                        IsActive = m.IsActive
                    }).ToList() ?? new()
            };
        }

        public static Classroom ToEntity(CreateClassroomDto dto)
        {
            return new Classroom
            {
                Id = Guid.NewGuid(),
                Title = dto.Title,
                Description = dto.Description,
                CourseId = dto.CourseId,
                MentorId = dto.MentorId,
                StartDate = dto.StartDate,
                CreatedAt = DateTime.UtcNow
            };
        }

        public static void UpdateEntity(Classroom classroom, UpdateClassroomDto dto)
        {
            if (!string.IsNullOrWhiteSpace(dto.Title))
                classroom.Title = dto.Title;
            if (!string.IsNullOrWhiteSpace(dto.Description))
                classroom.Description = dto.Description;
            if (dto.StartDate.HasValue)
                classroom.StartDate = dto.StartDate.Value;
            if (dto.IsActive.HasValue)
                classroom.IsActive = dto.IsActive.Value;
            classroom.UpdatedAt = DateTime.UtcNow;
        }
    }
}
