using System.ComponentModel.DataAnnotations;

namespace Registery.Models.Form
{
    public class UpdateFormOmsVM
    {
        [Required]
        public Guid Id { get; set; }

        [Display(Name = "Статус ОМС")]
        public Guid? OMSStatusId { get; set; }
    }
}
