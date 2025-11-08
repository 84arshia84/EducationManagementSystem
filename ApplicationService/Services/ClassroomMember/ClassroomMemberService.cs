using AppCore.UnitOfWork;
using ApplicationService.Dtos.ClassroomMember;
using ApplicationService.Mappers.ClassroomMembers;
using ApplicationService.ServicesContract.ClassroomMember;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ApplicationService.Services.ClassroomMember
{
    public class ClassroomMemberService : IClassroomMemberService
    {
        private readonly IUnitOfWork _uow;

        public ClassroomMemberService(IUnitOfWork uow)
        {
            _uow = uow;
        }

        public async Task<IEnumerable<ClassroomMemberDto>> GetAllAsync()
        {
            var members = await _uow.ClassroomMembers.GetAllAsync();
            return members.Select(ClassroomMemberMappers.ToDto);
        }

        public async Task<ClassroomMemberDto?> GetByIdAsync(Guid id)
        {
            var member = await _uow.ClassroomMembers.GetByIdAsync(id);
            return member == null ? null : ClassroomMemberMappers.ToDto(member);
        }

        public async Task<ClassroomMemberDto> CreateAsync(CreateClassroomMemberDto dto)
        {
            var entity = ClassroomMemberMappers.ToEntity(dto);

            await _uow.ClassroomMembers.AddAsync(entity);
            await _uow.SaveChangesAsync();

            var created = await _uow.ClassroomMembers.GetByIdAsync(entity.Id);

            return ClassroomMemberMappers.ToDto(created);
        }


        public async Task UpdateAsync(Guid id, UpdateClassroomMemberDto dto)
        {
            var existing = await _uow.ClassroomMembers.GetByIdAsync(id);
            if (existing == null) return;

            ClassroomMemberMappers.UpdateEntity(existing, dto);
            await _uow.ClassroomMembers.UpdateAsync(existing, id);
            await _uow.SaveChangesAsync();
        }

        public async Task DeleteAsync(Guid id)
        {
            await _uow.ClassroomMembers.DeleteAsync(id);
            await _uow.SaveChangesAsync();
        }
    }
}
