using AppCore.Entities.ClassroomMember;
using ApplicationService.Dtos.ClassroomMember;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ApplicationService.Mappers.ClassroomMembers
{
    public static class ClassroomMemberMappers
    {
        public static ClassroomMemberDto ToDto(ClassroomMember member)
        {
            return new ClassroomMemberDto
            {
                Id = member.Id,
                UserId = member.UserId,
                FullName = $"{member.User.FirstName} {member.User.LastName}",
                Email = member.User.Email,
                ClassroomId = member.ClassroomId,
                ClassroomTitle = member.Classroom.Title,
                IsActive = member.IsActive,
                JoinedAt = member.JoinedAt
            };
        }

        public static ClassroomMember ToEntity(CreateClassroomMemberDto dto)
        {
            return new ClassroomMember
            {
                Id = Guid.NewGuid(),
                UserId = dto.UserId,
                ClassroomId = dto.ClassroomId,
                JoinedAt = DateTime.UtcNow,
                IsActive = true
            };
        }

        public static void UpdateEntity(ClassroomMember member, UpdateClassroomMemberDto dto)
        {
            if (dto.IsActive.HasValue)
                member.IsActive = dto.IsActive.Value;
        }
    }
}
