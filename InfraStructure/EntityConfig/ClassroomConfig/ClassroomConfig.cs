using AppCore.Entities.Classroom;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InfraStructure.EntityConfig.ClassroomConfig
{
    internal class ClassroomConfig : IEntityTypeConfiguration<Classroom>
    {
        public void Configure(EntityTypeBuilder<Classroom> builder)
        {
            builder.ToTable("Classrooms");
            builder.HasKey(c => c.Id);

            builder.Property(c => c.Title)
                   .HasMaxLength(200)
                   .IsRequired();

            builder.Property(c => c.Description)
                   .HasMaxLength(2000)
                   .IsRequired(false);

            //builder.Property(c => c.SharePointFolderUrl)
            //       .HasMaxLength(1000)
            //       .IsRequired(false);

            builder.Property(c => c.IsActive)
                   .HasDefaultValue(true);

            builder.Property(c => c.CreatedAt)
                   .HasDefaultValueSql("GETUTCDATE()"); 

            builder.HasOne(c => c.Mentor)
                   .WithMany() 
                   .HasForeignKey(c => c.MentorId)
                   .OnDelete(DeleteBehavior.Restrict);

            builder.HasOne(c => c.Course)
                   .WithMany(cr => cr.Classrooms) 
                   .HasForeignKey(c => c.CourseId)
                   .OnDelete(DeleteBehavior.SetNull);

            builder.HasIndex(c => new { c.MentorId, c.CourseId });
        }
    }
}
