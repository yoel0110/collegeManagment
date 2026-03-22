using cm.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

internal class DepartmentConfiguration : IEntityTypeConfiguration<Department>
{
    public void Configure(EntityTypeBuilder<Department> builder)
    {
        builder.HasKey(d => d.DeparmentId);

        builder
            .HasOne<Faculty>()  
            .WithMany(f => f.Department)
            .HasForeignKey(d => d.FacultyId);
    }
}