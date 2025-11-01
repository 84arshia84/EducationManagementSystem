using AppCore.Entities.MentorProfiles;
using AppCore.Entities.StudentProfiles;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InfraStructure.EntityConfig.StudentProfileConfig
{
    internal class StudentProfileConfig : IEntityTypeConfiguration<StudentProfile>
    {
        public void Configure(EntityTypeBuilder<StudentProfile> builder)
        {
            builder.ToTable("StudentProfiles");
            builder.HasKey(x => x.Id);

            builder.Property(x => x.Skills).HasMaxLength(500);
            builder.Property(x => x.Languages).HasMaxLength(200);

            builder.HasOne(x => x.User)
                   .WithOne(x => x.StudentProfile)
                   .HasForeignKey<StudentProfile>(x => x.UserId)
                   .OnDelete(DeleteBehavior.Cascade);

            //  Many-to-Many با Course (از طریق StudentCourse)
            builder.HasMany(x => x.StudentCourses)
                   .WithOne(x => x.StudentProfile)
                   .HasForeignKey(x => x.StudentProfileId)
                   .OnDelete(DeleteBehavior.Cascade);
        }
    }
}
