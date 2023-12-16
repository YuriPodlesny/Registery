using Microsoft.AspNetCore.Identity;
using Registery.Application;
using Registery.Domain.Entities;

namespace Registry.DAL.DbInitialazer
{
    public class UserInitializer : IInitializer
    {
        private readonly ApplicationDbContext _db;
        private readonly UserManager<User> _userManager;
        private readonly RoleManager<IdentityRole> _roleManager;

        public UserInitializer(ApplicationDbContext db,
            UserManager<User> userManager,
            RoleManager<IdentityRole> roleManager)
        {
            _db = db;
            _userManager = userManager;
            _roleManager = roleManager;
        }
        public void Initialize()
        {
            string adminEmail = "admin@yandex.ru";
            string adminPassword = "123456";

            string adminRole = SD.Role.Администратор.ToString();
            string omsRole = SD.Role.ОМС.ToString();
            string rosreestrRole = SD.Role.Росреестр.ToString();

            string adminFirstName = "Имя";
            string adminLastName = "Фамилия";
            string adminMiddleName = "Отчество";

            if (!_roleManager.RoleExistsAsync(adminRole).GetAwaiter().GetResult())
            {
                _roleManager.CreateAsync(new IdentityRole(adminRole)).GetAwaiter().GetResult();
                _roleManager.CreateAsync(new IdentityRole(omsRole)).GetAwaiter().GetResult();
                _roleManager.CreateAsync(new IdentityRole(rosreestrRole)).GetAwaiter().GetResult();

                _userManager.CreateAsync(new User
                {
                    UserName = adminEmail,
                    FirstName = adminFirstName,
                    MiddleName = adminMiddleName,
                    LastName = adminLastName,
                    Email = adminEmail,
                    EmailConfirmed = true
                }, adminPassword).GetAwaiter().GetResult();

                User user = _db.Users.FirstOrDefault(u => u.Email == adminEmail)!;
                _userManager.AddToRoleAsync(user, adminRole).GetAwaiter().GetResult();
            }
        }
    }
}
