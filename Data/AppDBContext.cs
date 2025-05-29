using ExamSystemForSchool.Models;
using Microsoft.EntityFrameworkCore;

namespace ExamSystemForSchool.Data
{
    public class AppDBContext : DbContext
    {
        public AppDBContext(DbContextOptions<AppDBContext> options) : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<Exam>().HasOne(e => e.Student).WithMany(x => x.Exams).HasForeignKey(x => x.StudentCode);
            modelBuilder.Entity<Exam>().HasOne(e => e.Lesson).WithMany(x => x.Exams).HasForeignKey(x => x.LessonCode).HasPrincipalKey(l => l.Code);

        }

        public DbSet<Exam> Exams { get; set; }
        public DbSet<Lesson> Lessons { get; set; }
        public DbSet<Student> Students { get; set; }
    }
}
