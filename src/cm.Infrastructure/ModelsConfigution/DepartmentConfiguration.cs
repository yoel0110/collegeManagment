using cm.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
 
namespace cm.Infrastructure.ModelsConfigution
{
    internal class DepartmentConfiguration : IEntityTypeConfiguration<Department>
    {
        public void Configure(EntityTypeBuilder<Department> builder)
        {
            builder.HasKey(d => d.DeparmentId);
            builder
                    .HasOne(d => d.Faculty)
                    .WithMany(f => f.Department)
                    .HasForeignKey(d => d.FacultyId);
        }       
    }
}
