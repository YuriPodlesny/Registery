using Microsoft.AspNetCore.Identity;
using Registry.Domain.Entities;

namespace Registery.Domain.Entities
{
    public class User : IdentityUser
    {
        public string FirstName { get; set; } = null!;
        public string LastName { get; set; } = null!;
        public string MiddleName { get; set; } = null!;

        public Guid? OrganizationId { get; set; }
        public Organization Organization { get; set; } = null!;
    }
}
