using cm.Domain.Entities;
using cm.Infrastructure.ModelsConfigution;
using Microsoft.EntityFrameworkCore;

namespace cm.Infrastructure.Context
{
    public class AppDbContext: DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options): base(options)
        {
 
        }

        public DbSet<AcademicRecord> AcademicRecords { get; set; }
        public DbSet<CatalogCourse> CatalogCourses { get; set; }  
        public DbSet<Department> Departments { get; set; } 
        public DbSet<Enrollment> Enrollments { get; set; }
        public DbSet<Faculty> Faculties { get; set; }
        public DbSet<Professor> Professors { get; set; }
        public DbSet<Student> Students { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.ApplyConfiguration<AcademicRecord>(new AcademicRecordConfiguration());
            modelBuilder.ApplyConfiguration<CatalogCourse>(new CatalogCourseConfiguration()); 
            modelBuilder.ApplyConfiguration<Department>(new DepartmentConfiguration());
            modelBuilder.ApplyConfiguration<Enrollment>(new EnrollmentConfiguration());
            modelBuilder.ApplyConfiguration<Faculty>(new  FacultyConfiguration());
            modelBuilder.ApplyConfiguration<Professor>(new ProfessorConfiguration());
            modelBuilder.ApplyConfiguration<Student>(new StudentConfiguration());
        }
    }
}
