using AppCore.Entities.Courses;
using AppCore.UnitOfWork;
using ApplicationService.Dtos.Courses;
using ApplicationService.Dtos.Students;
using ApplicationService.Mappers.Courses;
using ApplicationService.ServicesContract.Course;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ApplicationService.Services.Course
{
    public class CourseService : ICourseService
    {
        private readonly IUnitOfWork _uow;

        public CourseService(IUnitOfWork uow)
        {
            _uow = uow;
        }

        public async Task<IEnumerable<CourseReadDto>> GetAllAsync()
        {
            var courses = await _uow.Courses.GetAllAsync();
            return courses.Select(CourseMapper.ToDto);
        }

        public async Task<CourseReadDto?> GetByIdAsync(Guid id)
        {
            var course = await _uow.Courses.GetByIdAsync(id);
            return course == null ? null : CourseMapper.ToDto(course);
        }

        public async Task<CourseReadDto> CreateAsync(CreateCourseDto dto)
        {
            var entity = CourseMapper.ToEntity(dto);
            await _uow.Courses.AddAsync(entity);
            await _uow.SaveChangesAsync();
            return CourseMapper.ToDto(entity);
        }

        public async Task UpdateAsync(Guid id, UpdateCourseDto dto)
        {
            var existing = await _uow.Courses.GetByIdAsync(id);
            if (existing == null) return;

            CourseMapper.UpdateEntity(existing, dto);
            await _uow.Courses.UpdateAsync(existing, id);
            await _uow.SaveChangesAsync();
        }

        public async Task DeleteAsync(Guid id)
        {
            await _uow.Courses.DeleteByIdAsync(id);
            await _uow.SaveChangesAsync();
        }
    }
}
