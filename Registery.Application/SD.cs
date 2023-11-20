using System.ComponentModel.DataAnnotations;

namespace Registery.Application
{
    public static class SD
    {
        public enum Role
        {
            [Display(Name = "Сотрудник Росреестра")]
            Росреестр,
            [Display(Name = "Сотрудник ОМС")]
            ОМС,
            [Display(Name = "Администратор")]
            Администратор
        }
    }
}
