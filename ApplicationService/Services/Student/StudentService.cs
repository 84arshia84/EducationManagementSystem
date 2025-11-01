using AppCore.UnitOfWork;
using ApplicationService.Dtos.Students;
using ApplicationService.Mappers.Students;
using ApplicationService.ServicesContract.Student;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ApplicationService.Services.Student
{
    public class StudentService : IStudentService
    {
        private readonly IUnitOfWork _uow;

        public StudentService(IUnitOfWork uow)
        {
            _uow = uow;
        }

        public async Task<IEnumerable<StudentReadDto>> GetAllAsync()
        {
            var students = await _uow.Students.GetAllAcync();
            return students.Select(StudentMapper.ToDto);
        }

        public async Task<StudentReadDto?> GetByIdAsync(Guid id)
        {
            var student = await _uow.Students.GetByIdAcync(id);
            return student == null ? null : StudentMapper.ToDto(student);
        }

        public async Task<StudentReadDto> CreateAsync(CreateStudentDto dto)
        {
            var entity = StudentMapper.ToEntity(dto);
            await _uow.Students.AddAcync(entity);
            await _uow.SaveChangesAsync();
            return StudentMapper.ToDto(entity);
        }

        public async Task UpdateAsync(Guid id, UpdateStudentDto dto)
        {
            var existing = await _uow.Students.GetByIdAcync(id);
            if (existing == null) return;

            StudentMapper.UpdateEntity(existing, dto);
            await _uow.Students.UpdateAcync(existing, id);
            await _uow.SaveChangesAsync();
        }

        public async Task DeleteAsync(Guid id)
        {
            await _uow.Students.DeleteByIdAcync(id);
            await _uow.SaveChangesAsync();
        }
    }
}
