using System.ComponentModel.DataAnnotations;

namespace Registery.Models.OMSStatuses
{
    public class UpdateOMSStatusVM
    {
        [Required]
        public Guid Id { get; set; }

        [Required]
        public string? Value { get; set; }
    }
}
