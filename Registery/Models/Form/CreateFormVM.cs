using Registry.Domain.Entities;
using System.ComponentModel.DataAnnotations;

namespace Registery.Models.Form
{
    public class CreateFormVM
    {
        [Required]
        [Display(Name = "Кадастровый номер")]
        public string CadastralNumber { get; set; }

        [Display(Name = "Адрес")]
        public string? Address { get; set; }

        [Display(Name = "Статус ЕГРН")]
        public string? StatusEGRN { get; set; }

        [Display(Name = "Номер района")]
        public Guid? DistrictNumberId { get; set; }

        [Display(Name = "Статус Росреестра")]
        public Guid? RosreestrStatusId { get; set; }

        [Display(Name = "Статус ОМС")]
        public Guid? OMSStatusId { get; set; }
    }
}
