using cm.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

internal class StudentConfiguration : IEntityTypeConfiguration<Student>
{
    public void Configure(EntityTypeBuilder<Student> builder)
    {
        builder.HasKey(s => s.StudentID);

        builder
            .HasOne(s => s.AcademicRecord)
            .WithOne(a => a.Student)
            .HasForeignKey<AcademicRecord>(a => a.StudentId);
    }
}