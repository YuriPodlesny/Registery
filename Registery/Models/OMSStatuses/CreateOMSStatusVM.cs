using System.ComponentModel.DataAnnotations;

namespace Registery.Models.OMSStatuses
{
    public class CreateOMSStatusVM
    {
        [Required]
        public string? Value { get; set; }
    }
}
