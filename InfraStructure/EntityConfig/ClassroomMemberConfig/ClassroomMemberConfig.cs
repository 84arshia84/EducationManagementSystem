using AppCore.Entities.ClassroomMember;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InfraStructure.EntityConfig.ClassroomMemberConfig
{
    internal class ClassroomMemberConfig : IEntityTypeConfiguration<ClassroomMember>
    {
        public void Configure(EntityTypeBuilder<ClassroomMember> builder)
        {
            builder.ToTable("ClassroomMembers");
            builder.HasKey(cm => cm.Id);

            builder.Property(cm => cm.JoinedAt).HasDefaultValueSql("GETUTCDATE()");

            // Relation: Classroom 1 -> N ClassroomMember
            builder.HasOne(cm => cm.Classroom)
                   .WithMany(c => c.Members)
                   .HasForeignKey(cm => cm.ClassroomId)
                   .OnDelete(DeleteBehavior.Cascade);

            // Relation: User 1 -> N ClassroomMember
            builder.HasOne(cm => cm.User)
                   .WithMany() // اگر User کلاس Nav برای کلاس‌ها داشته باشی، می‌تونی آن را قرار دهی
                   .HasForeignKey(cm => cm.UserId)
                   .OnDelete(DeleteBehavior.Restrict);

            // Ensure a user can't be duplicate member of same Classroom
            builder.HasIndex(cm => new { cm.ClassroomId, cm.UserId }).IsUnique();
        }
    }
}
