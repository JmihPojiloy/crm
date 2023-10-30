using Microsoft.AspNetCore.Identity;
using Notes.Identity.Models;

namespace Notes.Identity
{
    public static class RoleInitializer
    {
        public static async Task InitializeAsync(UserManager<AppUser> userManager,
            RoleManager<IdentityRole> roleManager)
        {
            string adminLogin = "admin";
            string adminPassword = "admin";

            if(await roleManager.FindByNameAsync("admin") == null)
            {
                await roleManager.CreateAsync(new IdentityRole("admin"));
            }

            if(await roleManager.FindByNameAsync("user") ==  null)
            {
                await roleManager.CreateAsync(new IdentityRole("user"));
            }

            if (await userManager.FindByNameAsync(adminLogin) == null)
            {
                AppUser admin = new AppUser { UserName = adminLogin };
                IdentityResult result = await userManager.CreateAsync(admin, adminPassword);

                if(result.Succeeded)
                {
                    await userManager.AddToRoleAsync(admin, "admin");
                }
            }
        }
    }
}
