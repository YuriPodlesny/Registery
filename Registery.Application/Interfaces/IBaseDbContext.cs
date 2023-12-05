using Microsoft.EntityFrameworkCore;
using Registry.Domain.Entities;

namespace Registery.Application.Interfaces
{
    public interface IBaseDbContext
    {
        public DbSet<DistrictNumber> DistrictNumbers { get; set; }
        public DbSet<Form> Forms { get; set; }
        public DbSet<Organization> Organizations { get; set; }
        public DbSet<RosreestrStatus> RosreestrStatuses { get; set; }
        public DbSet<OMSStatus> OMSStatuses { get; set; }

        public Task<int> SaveChangesAsync(CancellationToken cancellationToken);
    }
}
