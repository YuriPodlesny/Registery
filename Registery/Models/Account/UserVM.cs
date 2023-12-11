using System.ComponentModel.DataAnnotations;

namespace Registery.Models.Account
{
    public class UserVM
    {
        [Required]
        [Display(Name = "Имя")]
        public string FirstName { get; set; } = null!;
        [Required]
        [Display(Name = "Фамилия")]
        public string LastName { get; set; } = null!;
        [Required]
        [Display(Name = "Отчество")]
        public string MiddleName { get; set; } = null!;
        [Required]
        [Display(Name = "Email")]
        public string Email { get; set; } = null!;
        [Required]
        [Display(Name = "Наименование организации")]
        public string OrganizationName { get; set; } = null!;
    }
}
