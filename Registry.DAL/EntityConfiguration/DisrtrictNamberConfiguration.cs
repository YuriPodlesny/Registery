using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Registry.Domain.Entities;

namespace Registry.DAL.EntityConfiguration
{
    public class DisrtrictNamberConfiguration : IEntityTypeConfiguration<DistrictNumber>
    {
        public void Configure(EntityTypeBuilder<DistrictNumber> builder)
        {
            builder.HasKey(e => e.Id);

            builder.Property(e => e.Value).IsRequired();

            builder.HasMany(e => e.Organizations)
                .WithOne(e => e.DistrictNumber)
                .HasForeignKey(e => e.DistrictNumberId)
                .IsRequired();

            builder.HasMany(e => e.Forms)
                .WithOne(e => e.DistrictNumber)
                .HasForeignKey(e => e.DistrictNumberId)
                .IsRequired(false);
        }
    }
}
