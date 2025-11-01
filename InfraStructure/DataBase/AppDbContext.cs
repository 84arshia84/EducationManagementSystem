using AppCore.Entities.Courses;
using AppCore.Entities.MentorProfiles;
using AppCore.Entities.StudentProfiles;
using AppCore.Entities.Users;
using InfraStructure.EntityConfig.CourseConfig;
using InfraStructure.EntityConfig.MentorProfileConfig;
using InfraStructure.EntityConfig.StudentProfileConfig;
using InfraStructure.EntityConfig.UserProfileConfig;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Diagnostics.Metrics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InfraStructure.DataBase
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions options) : base(options)
        {

        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.ApplyConfiguration(new MentorProfileConfig());
            modelBuilder.ApplyConfiguration(new StudentProfileConfig());
            modelBuilder.ApplyConfiguration(new UserConfig());
            modelBuilder.ApplyConfiguration(new CourseConfig());

        }
        public DbSet<User> Users { get; set; }
        public DbSet<MentorProfile> MentorProfiles { get; set; }
        public DbSet<StudentProfile> StudentProfiles { get; set; }
        public DbSet<Course> Courses { get; set; }

    }
}
