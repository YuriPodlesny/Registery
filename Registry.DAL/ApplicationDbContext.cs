using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Registery.Application.Interfaces;
using Registery.Domain.Entities;
using Registry.DAL.EntityConfiguration;
using Registry.Domain.Entities;

namespace Registry.DAL
{
    public class ApplicationDbContext : IdentityDbContext<User>, IBaseDbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options) 
        {
        }

        public DbSet<DistrictNumber> DistrictNumbers { get; set; }
        public DbSet<Form> Forms { get; set; }
        public DbSet<Organization> Organizations { get; set; }
        public DbSet<RosreestrStatus> RosreestrStatuses { get; set; }
        public DbSet<OMSStatus> OMSStatuses { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder
                .ApplyConfiguration(new FormConfiguration())
                .ApplyConfiguration(new DisrtrictNamberConfiguration())
                .ApplyConfiguration(new OMSStatusConfiguration())
                .ApplyConfiguration(new OrganizationConfiguration())
                .ApplyConfiguration(new RosreestrStatusConfiguration())
                .ApplyConfiguration(new UserConfiguration());

            base.OnModelCreating(modelBuilder);
        }
    }
}