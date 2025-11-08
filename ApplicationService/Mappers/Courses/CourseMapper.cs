using AppCore.Entities.Courses;
using ApplicationService.Dtos.Courses;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ApplicationService.Mappers.Courses
{
    public static class CourseMapper
    {
        public static CourseReadDto ToDto(Course course)
        {
            return new CourseReadDto
            {
                Id = course.Id,
                Title = course.Title, 
                CreatedAt = course.CreatedAt,
               
            };
        }

        public static Course ToEntity(CreateCourseDto dto)
        {
            return new Course
            {
                Title = dto.Title,
            };
        }

        public static void UpdateEntity(Course course, UpdateCourseDto dto)
        {
            course.Title = dto.Title;
        }
    }
}
