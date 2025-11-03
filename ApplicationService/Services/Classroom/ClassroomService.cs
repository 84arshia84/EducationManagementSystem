using AppCore.UnitOfWork;
using ApplicationService.Dtos.Classroom;
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
        public ClassroomService (IUnitOfWork uow)
        {
            _uow = uow;
        }

        public async Task<ClassroomDto> CreateAsync(CreateClassroomDto dto)
        {
            throw new NotImplementedException();
        }

        public async Task DeleteAsync(Guid id)
        {
            throw new NotImplementedException();
        }

        public async Task<IEnumerable<ClassroomDto>> GetAllAsync()
        {
            throw new NotImplementedException();
        }

        public async Task<ClassroomDto?> GetByIdAsync(Guid id)
        {
            throw new NotImplementedException();
        }

        public async Task UpdateAsync(Guid id, UpdateClassroomDto dto)
        {
            throw new NotImplementedException();
        }
    }
}
