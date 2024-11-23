using ExaminationSystem.Model;
using ExaminationSystem.Models;
using Microsoft.EntityFrameworkCore;
using System.Diagnostics;
using System.Reflection;

namespace ExaminationSystem.Data
{
    public class AppDbContext(IConfiguration config) : DbContext
    {
        private readonly IConfiguration config = config;

        public DbSet<Instructor> Instructors { get; set; }
        public DbSet<Student> Students{ get; set; }
        public DbSet<Course> Courses { get; set; }
        public DbSet<StudentCourse> StudentCourses { get; set; }
        public DbSet<Exam> Exams { get; set; }
        public DbSet<Question> Questions { get; set; }
        public DbSet<Choice> Choices { get; set; }
        public DbSet<ExamResult> ExamResults { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            string connectionString = config["ConnectionStrings:DefaultConnection"]!;
            optionsBuilder.UseSqlServer(connectionString,
                b=>b.MigrationsAssembly("ExaminationSystem"))
                .UseQueryTrackingBehavior(QueryTrackingBehavior.NoTracking)
                .LogTo(log => Debug.WriteLine(log), LogLevel.Information);
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());
        }
    }
}
