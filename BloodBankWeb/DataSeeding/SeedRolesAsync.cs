using Microsoft.AspNetCore.Identity;

namespace BloodBankWeb.DataSeeding
{
    public static class SeedRolesAsync
    {

        public static async Task seedRoles(RoleManager<IdentityRole> roleManager)
        {
            if (!roleManager.Roles.Any())
            {
                await roleManager.CreateAsync(new IdentityRole(AppRoles.Admin));
                await roleManager.CreateAsync(new IdentityRole(AppRoles.subAdmin));
                await roleManager.CreateAsync(new IdentityRole(AppRoles.User));

            }
        }
    }
}
