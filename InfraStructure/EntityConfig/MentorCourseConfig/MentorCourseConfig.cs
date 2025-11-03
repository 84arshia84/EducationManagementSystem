using AppCore.Entities.MentorProfiles;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InfraStructure.EntityConfig.MentorCourseConfig
{
    internal class MentorCourseConfig : IEntityTypeConfiguration<MentorCourse>
    {
        public void Configure(EntityTypeBuilder<MentorCourse> builder)
        {
            builder.ToTable("MentorCourses");
            builder.HasKey(x => x.Id);

            builder.HasOne(mc => mc.MentorProfile)
                   .WithMany(mp => mp.MentorCourses)
                   .HasForeignKey(mc => mc.MentorUserId) // <- changed
                   .OnDelete(DeleteBehavior.Cascade);

            builder.HasOne(mc => mc.Course)
                   .WithMany(c => c.MentorCourses)
                   .HasForeignKey(mc => mc.CourseId)
                   .OnDelete(DeleteBehavior.Cascade);
        }

    }
}
