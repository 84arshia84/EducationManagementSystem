using ApplicationService.Dtos.Courses;
using ApplicationService.Dtos.Students;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ApplicationService.ServicesContract.Course
{
   
        public interface ICourseService
        {
            Task<IEnumerable<CourseReadDto>> GetAllAsync();
            Task<CourseReadDto?> GetByIdAsync(Guid id);
            Task<CourseReadDto> CreateAsync(CreateCourseDto dto);
            Task UpdateAsync(Guid id, UpdateCourseDto dto);
            Task DeleteAsync(Guid id);
        }

    }

