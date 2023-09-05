using Diary.Models.Configurations;
using Diary.Models.Domains;
using Diary.Properties;
using System;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Linq;

namespace Diary
{
    public class ApplicationDbContext : DbContext
    {
        private static string _connectionString = $@"
            Server={Settings.Default.ServerAddress}\{Settings.Default.ServerName};
            Database={Settings.Default.Database};
            Trusted_Connection=True;"; 


        public ApplicationDbContext()
            : base(_connectionString)
        {
        }

        public DbSet<Student> Students { get; set; }
        public DbSet<Group> Groups { get; set; }
        public DbSet<Rating> Ratings { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Configurations.Add(new StudentConfiguration());
            modelBuilder.Configurations.Add(new RatingConfiguration());
            modelBuilder.Configurations.Add(new GroupConfiguration());
        }
    }  
}