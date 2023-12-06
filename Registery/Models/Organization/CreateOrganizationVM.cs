using System.ComponentModel.DataAnnotations;

namespace Registery.Models.Organization
{
    public class CreateOrganizationVM
    {
        [Required]
        public required string Name { get; set; }
        [Required]
        public required string INN { get; set; }
        [Required]
        public Guid DistrictNumberId { get; set; }
    }
}
