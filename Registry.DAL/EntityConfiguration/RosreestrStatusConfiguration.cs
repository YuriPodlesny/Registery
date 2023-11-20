using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Registry.Domain.Entities;

namespace Registry.DAL.EntityConfiguration
{
    public class RosreestrStatusConfiguration : IEntityTypeConfiguration<RosreestrStatus>
    {
        public void Configure(EntityTypeBuilder<RosreestrStatus> builder)
        {
            builder.HasKey(x => x.Id);

            builder.HasMany(e => e.Forms)
                .WithOne(e => e.RosreestrStatus)
                .HasForeignKey(e => e.RosreestrStatusId)
                .IsRequired(false);
        }
    }
}
