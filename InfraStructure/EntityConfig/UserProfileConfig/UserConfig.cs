
using AppCore.Entities.StudentProfiles;
using AppCore.Entities.Users;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InfraStructure.EntityConfig.UserProfileConfig
{
    internal class UserConfig : IEntityTypeConfiguration<User>
    {
        public void Configure(EntityTypeBuilder<User> builder)
        {
            builder.ToTable("Users");
            builder.HasKey(x => x.Id);

            builder.Property(x => x.FirstName)
                   .HasMaxLength(100)
                   .IsRequired();

            builder.Property(x => x.LastName)
                   .HasMaxLength(100)
                   .IsRequired();

            builder.Property(x => x.Email)
                   .HasMaxLength(200)
                   .IsRequired();

            builder.HasOne(x => x.StudentProfile)
                   .WithOne(x => x.User)
                   .HasForeignKey<AppCore.Entities.StudentProfiles.StudentProfile>(x => x.UserId)
                   .OnDelete(DeleteBehavior.Cascade);

            builder.HasOne(x => x.MentorProfile)
                   .WithOne(x => x.User)
                   .HasForeignKey<AppCore.Entities.MentorProfiles.MentorProfile>(x => x.UserId)
                   .OnDelete(DeleteBehavior.Cascade);
        }
    }
}
