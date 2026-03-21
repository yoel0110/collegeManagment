using cm.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

internal class CatalogCourseConfiguration : IEntityTypeConfiguration<CatalogCourse>
{
    public void Configure(EntityTypeBuilder<CatalogCourse> builder)
    {
        builder.HasKey(c => c.SubjectId);

        builder
            .HasOne(c => c.Professor)
            .WithMany(p => p.CatalogCourse)
            .HasForeignKey(c => c.ProfesorId);
    }
}