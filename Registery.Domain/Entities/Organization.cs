using Registery.Domain.Entities;
using Registry.Domain.Entities.Base;

namespace Registry.Domain.Entities
{
    public class Organization : BaseEntity
    {
        public required string Name { get; set; }
        public required string INN { get; set; }
        public bool Delete { get; set; } = false;

        public Guid DistrictNumberId { get; set; }
        public DistrictNumber? DistrictNumber { get; set; }

        public IList<User> Organizations { get; } = new List<User>();
    }
}
