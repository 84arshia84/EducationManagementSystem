using AppCore.UnitOfWork;
using ApplicationService.Dtos.Mentors;
using ApplicationService.Mappers.Mentors;
using ApplicationService.ServicesContract.Mentor;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ApplicationService.Services.Mentor
{
    public class MentorService : IMentorService
    {
        private readonly IUnitOfWork _uow;

        public MentorService(IUnitOfWork uow)
        {
            _uow = uow;
        }

        public async Task<IEnumerable<MentorReadDto>> GetAllAsync()
        {
            var mentors = await _uow.Mentors.GetAllAsync();
            return mentors.Select(MentorMapper.ToDto);
        }

        public async Task<MentorReadDto?> GetByIdAsync(Guid id)
        {
            var mentor = await _uow.Mentors.GetByIdAsync(id);
            return mentor == null ? null : MentorMapper.ToDto(mentor);
        }

        public async Task<MentorReadDto> CreateAsync(CreateMentorDto dto)
        {
            var entity = MentorMapper.ToEntity(dto);
            await _uow.Mentors.AddAsync(entity);
            await _uow.SaveChangesAsync();
            return MentorMapper.ToDto(entity);
        }
        public async Task DeleteAsync(Guid id)
        {
            await _uow.Mentors.DeleteByIdAsync(id);
            await _uow.SaveChangesAsync();
        }

        public async Task UpdateAsync(Guid id, UpdateMentorDto dto)
        {
            var existing = await _uow.Mentors.GetByIdAsync(id);
            if (existing == null) return;

            MentorMapper.UpdateEntity(existing, dto);
            await _uow.Mentors.UpdateAsync(existing, id);
            await _uow.SaveChangesAsync();
        }


        public async Task UpdateMentorStatusAsync(Guid id, UpdateMentorStatusDto dto)
        {
            var existing = await _uow.Mentors.GetByIdAsync(id);
            if (existing == null) return;
            existing.IsMentorApproved = dto.IsMentorApproved;
            await _uow.SaveChangesAsync();
        }
    }
}
