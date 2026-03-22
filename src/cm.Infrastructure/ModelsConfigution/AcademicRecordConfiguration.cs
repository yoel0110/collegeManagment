using cm.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

internal class AcademicRecordConfiguration : IEntityTypeConfiguration<AcademicRecord>
{
    public void Configure(EntityTypeBuilder<AcademicRecord> builder)
    {
        builder.HasKey(ar => ar.RecordID);
    }
}