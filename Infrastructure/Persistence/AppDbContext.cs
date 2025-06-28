using Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Persistence
{
    public class AppDbContext: DbContext
    {
        public DbSet<Student> Students => Set<Student>();
        public DbSet<Course> Courses => Set<Course>();
        public DbSet<Enrollment> Enrollments => Set<Enrollment>();

        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) { }
        
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Enrollment>()
                .HasKey( entity => new { entity.StudentId, entity.CourseId});

            modelBuilder.Entity<Enrollment>()
                .HasOne(entity => entity.Student)
                .WithMany(entity => entity.Enrollments)
                .HasForeignKey(entitty => entitty.StudentId)
                .OnDelete(DeleteBehavior.Cascade);

            modelBuilder.Entity<Enrollment>()
                .HasOne(entity => entity.Course)
                .WithMany(entity => entity.Enrollments)
                .HasForeignKey(entitty => entitty.CourseId)
                .OnDelete(DeleteBehavior.Cascade); ;

            modelBuilder.Entity<Student>()
                .HasIndex(entity => entity.Email)
                .IsUnique();

            modelBuilder.Entity<Student>()
                .HasIndex(entity => entity.Document)
                .IsUnique();

            modelBuilder.Entity<Course>()
                .HasIndex(entity => entity.Code)
                .IsUnique();
        }
    }
}
