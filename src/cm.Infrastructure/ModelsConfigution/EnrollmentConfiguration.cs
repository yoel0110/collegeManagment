using cm.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace cm.Infrastructure.ModelsConfigution
{
    internal class EnrollmentConfiguration : IEntityTypeConfiguration<Enrollment>
    {
        public void Configure(EntityTypeBuilder<Enrollment> builder)
        {
            builder.HasKey(e => e.EnrollMentID);
            builder
                    .HasMany(e => e.CatalogCourse)
                    .WithOne(cc => cc.Enrollment)
                    .HasForeignKey(cc =>cc.EnrollmentID);
        }
    }
}
