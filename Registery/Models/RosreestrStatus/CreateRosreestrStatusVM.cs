using System.ComponentModel.DataAnnotations;

namespace Registery.Models.RosreestrStatus
{
    public class CreateRosreestrStatusVM
    {
        [Required]
        public string? Value { get; set; }
    }
}
