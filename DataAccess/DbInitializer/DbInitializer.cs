using CatchMore.DataAccess.Data;
using CatchMore.Models;
using CatchMore.Utility;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;

namespace CatchMore.DataAccess.DbInitializer
{
    public class DbInitializer : IDbInitializer
    {
        private readonly UserManager<IdentityUser> _userManager;
        private readonly RoleManager<IdentityRole> _roleManager;
        private readonly ApplicationDbContext _db;

        public DbInitializer(
            UserManager<IdentityUser> userManager,
            RoleManager<IdentityRole> roleManager,
            ApplicationDbContext db)
        {
            _userManager = userManager;
            _roleManager = roleManager;
            _db = db;
        }

        public void Initialize()
        {
            // Migrate pending migrations
            try
            {
                if (_db.Database.GetPendingMigrations().Count() > 0)
                {
                    _db.Database.Migrate();
                }
            }
            catch (Exception ex)
            {
            }

            _db.Database.EnsureCreated();

            // Create Roles
            if (!_roleManager.RoleExistsAsync(SD.Role_Admin).GetAwaiter().GetResult())
            {
                _roleManager.CreateAsync(new IdentityRole(SD.Role_Customer)).GetAwaiter().GetResult();
                _roleManager.CreateAsync(new IdentityRole(SD.Role_Company)).GetAwaiter().GetResult();
                _roleManager.CreateAsync(new IdentityRole(SD.Role_Admin)).GetAwaiter().GetResult();
                _roleManager.CreateAsync(new IdentityRole(SD.Role_Employee)).GetAwaiter().GetResult();

                // Create Admin User
                // TODO: Debug CreateAsync, this gives "Invalid login attempt" for created user.
                _userManager.CreateAsync(new ApplicationUser
                {
                    UserName = "ADMIN-Alexander",
                    UserNameHandle = "ADMIN-Alexander",
                    Email = "catchmoreapp@gmail.com",
                    EmailConfirmed = true,
                }, "Admin123!123!").GetAwaiter().GetResult();

                ApplicationUser user = _db.ApplicationUsers.FirstOrDefault(e => e.Email == "catchmoreapp@gmail.com");
                _userManager.AddToRoleAsync(user, SD.Role_Admin).GetAwaiter().GetResult();
            }
            return;
        }
    }
}
