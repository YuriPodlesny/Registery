using System.ComponentModel.DataAnnotations;

namespace Registery.Models.DistrictNumber
{
    public class CreateDistrictNumberVM
    {
        [Required]
        public string? Value { get; set; }
    }
}
