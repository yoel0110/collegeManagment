using cm.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

internal class AcademicRecordConfiguration : IEntityTypeConfiguration<AcademicRecord>
{
    public void Configure(EntityTypeBuilder<AcademicRecord> builder)
    {
        builder.HasKey(ar => ar.RecordID);

        builder
            .HasMany(a => a.Enrollment)
            .WithOne(e => e.AcademicRecord)
            .HasForeignKey(e => e.RecordID);
    }
}