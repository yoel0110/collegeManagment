using cm.api.Models;
using Microsoft.EntityFrameworkCore;

namespace cm.api.Context
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
            modelBuilder.Entity<AcademicRecord>()
                .Property(p => p.RecordID)
                .ValueGeneratedOnAdd();
                    
        }
    }
}
