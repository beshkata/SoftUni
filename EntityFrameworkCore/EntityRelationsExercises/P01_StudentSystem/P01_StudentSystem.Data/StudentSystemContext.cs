namespace P01_StudentSystem.Data
{
    using Microsoft.EntityFrameworkCore;
    using P01_StudentSystem.Data.Models;

    public class StudentSystemContext : DbContext
    {
        public StudentSystemContext()
        {

        }

        public StudentSystemContext(DbContextOptions options)
            : base(options)
        {

        }

        public virtual DbSet<Course> Courses { get; set; }

        public virtual DbSet<Homework> HomeworkSubmissions { get; set; }

        public virtual DbSet<Resource> Resources { get; set; }

        public virtual DbSet<Student> Students { get; set; }

        public virtual DbSet<StudentCourse> StudentCourses { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            base.OnConfiguring(optionsBuilder);

            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder.UseSqlServer(Configuring.CONNECTION_STRING);
            }
        }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            builder.Entity<StudentCourse>()
                .HasKey(sc => new { sc.StudentId, sc.CourseId});

            builder.Entity<Student>(entity =>
            {
                entity.Property(s => s.PhoneNumber).IsUnicode(false);
                entity.Property(s => s.Name).IsUnicode(true);
                entity.Property(s => s.Birthday).IsRequired(false);
            });

            builder.Entity<Resource>(entity =>
            {
                entity.Property(r => r.Url).IsUnicode(false);
            });

            builder.Entity<Homework>(entity =>
            {
                entity.Property(h => h.Content).IsUnicode(false);
            });
        }
    }
}
