using System.ComponentModel.DataAnnotations;

namespace Registery.Models.Account
{
    public class LoginVM
    {
        [Required]
        [Display(Name = "Логин(Email)")]
        public string Email { get; set; } = null!;

        [Required]
        [DataType(DataType.Password)]
        [Display(Name = "Пароль")]
        public string Password { get; set; } = null!;

        [Display(Name = "Запомнить?")]
        public bool RememberMe { get; set; }

        public string? ReturnUrl { get; set; }
    }
}
