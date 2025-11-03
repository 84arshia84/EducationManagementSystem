using AppCore.Entities.MentorProfiles;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InfraStructure.EntityConfig.MentorProfileConfig
{

    internal class MentorProfileConfig : IEntityTypeConfiguration<MentorProfile>
    {
        public void Configure(EntityTypeBuilder<MentorProfile> builder)
        {
            builder.ToTable("MentorProfiles");

            // قبلاً HasKey(x => x.Id); بود — اکنون UserId کلید اصلی است:
            builder.HasKey(x => x.UserId);

            builder.Property(x => x.Skills).HasMaxLength(500);
            builder.Property(x => x.ResumeUrl).HasMaxLength(500);

            builder.HasOne(x => x.User)
                   .WithOne(x => x.MentorProfile)
                   .HasForeignKey<MentorProfile>(x => x.UserId)
                   .OnDelete(DeleteBehavior.Cascade);

            builder.HasMany(x => x.MentorCourses)
                   .WithOne(x => x.MentorProfile)
                   .HasForeignKey(x => x.MentorUserId)
                   .OnDelete(DeleteBehavior.Cascade);
        }
    }
}
