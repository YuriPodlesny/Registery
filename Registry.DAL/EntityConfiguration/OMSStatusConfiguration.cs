using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Registry.Domain.Entities;

namespace Registry.DAL.EntityConfiguration
{
    public class OMSStatusConfiguration : IEntityTypeConfiguration<OMSStatus>
    {
        public void Configure(EntityTypeBuilder<OMSStatus> builder)
        {
            builder.HasKey(e => e.Id);

            builder.HasMany(e => e.Forms)
                .WithOne(e => e.OMSStatus)
                .HasForeignKey(e => e.OMSStatusId)
                .IsRequired(false);
        }
    }
}
