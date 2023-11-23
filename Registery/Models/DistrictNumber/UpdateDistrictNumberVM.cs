using System.ComponentModel.DataAnnotations;

namespace Registery.Models.DistrictNumber
{
    public class UpdateDistrictNumberVM
    {
        [Required]
        public Guid Id { get; set; }

        [Required]
        public string? Value { get; set; }
    }
}
