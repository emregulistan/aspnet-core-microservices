using Identity.API.Data;
using Identity.API.Models;
using Microsoft.AspNetCore.Identity;

namespace Identity.API.Extensions
{
    public class Seed
    {
        public static async Task SeedData(IdentityContext context, UserManager<ApplicationUser> userManager)
        {
            if(!userManager.Users.Any())
            {
                var users = new List<ApplicationUser>
                {
                    new ApplicationUser
                    {
                        FullName = "User",
                        EmailConfirmed = true,
                        PhoneNumberConfirmed = true,
                        TwoFactorEnabled = true,
                        LockoutEnabled = true,
                        AccessFailedCount = 15
                    }
                };
                foreach (var user in users)
                {
                    await userManager.CreateAsync(user, "Pa$$w0rd");
                }
            }
        }
    }
}
