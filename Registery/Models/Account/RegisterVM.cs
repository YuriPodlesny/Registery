using System.ComponentModel.DataAnnotations;

namespace Registery.Models.Account
{
    public class RegisterVM
    {
        [Required(ErrorMessage = "Не указан Email")]
        [DataType(DataType.EmailAddress)]
        [Display(Name = "Email")]
        public string Email { get; set; } = null!;

        [Required(ErrorMessage = "Не указан пароль")]
        [StringLength(50, MinimumLength = 6, ErrorMessage = "Длина пароля должна быть больше 6 символов")]
        [DataType(DataType.Password)]
        [Display(Name = "Пароль")]
        public string Password { get; set; } = null!;

        [Required(ErrorMessage = "Введите пароль еще раз")]
        [Compare("Password", ErrorMessage = "Пароли не совпадают")]
        [DataType(DataType.Password)]
        [Display(Name = "Подтвердить пароль")]
        public string ConfirmPassword { get; set; } = null!;

        [Required(ErrorMessage = "Укажите имя")]
        [StringLength(50)]
        [DataType(DataType.Text)]
        [Display(Name = "Имя")]
        public string FirstName { get; set; } = null!;

        [Required(ErrorMessage = "Укажите отчество")]
        [StringLength(50)]
        [DataType(DataType.Text)]
        [Display(Name = "Отчество")]
        public string MiddleName { get; set; } = null!;

        [Required(ErrorMessage = "Укажите фамилию")]
        [StringLength(50)]
        [DataType(DataType.Text)]
        [Display(Name = "Фамилия")]
        public string LastName { get; set; } = null!;

        [Required]
        [Display(Name = "Роль")]
        public string Role { get;set; } = null!;

        [Required]
        [Display(Name = "Организация")]
        public Guid? OrganizationId { get; set; }
    }
}
