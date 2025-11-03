using AppCore.UnitOfWork;
using ApplicationService.Dtos.Classroom;
using ApplicationService.Mappers.Classrooms;
using ApplicationService.ServicesContract.Classroom;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ApplicationService.Services.Classroom
{
    public class ClassroomService : IClassroomService
    {
        private readonly IUnitOfWork _uow;
        public ClassroomService(IUnitOfWork uow)
        {
            _uow = uow;
        }

        public async Task<IEnumerable<ClassroomDto>> GetAllAsync()
        {
            var classrooms = await _uow.Classrooms.GetAllAsync();
            return classrooms.Select(ClassroomMapper.ToDto);
        }

        public async Task<ClassroomDto?> GetByIdAsync(Guid id)
        {
            var classroom = await _uow.Classrooms.GetByIdAsync(id);
            return classroom == null ? null : ClassroomMapper.ToDto(classroom);
        }

        public async Task<ClassroomDto> CreateAsync(CreateClassroomDto dto)
        {
            var entity = ClassroomMapper.ToEntity(dto);
            await _uow.Classrooms.AddAsync(entity);
            await _uow.SaveChangesAsync();
            return ClassroomMapper.ToDto(entity);
        }

        public async Task UpdateAsync(Guid id, UpdateClassroomDto dto)
        {
            var existing = await _uow.Classrooms.GetByIdAsync(id);
            if (existing == null) return;

            ClassroomMapper.UpdateEntity(existing, dto);
            await _uow.Classrooms.UpdateAsync(existing, id);
            await _uow.SaveChangesAsync();
        }

        public async Task DeleteAsync(Guid id)
        {
            await _uow.Classrooms.DeleteAsync(id);
            await _uow.SaveChangesAsync();
        }

    }
}
