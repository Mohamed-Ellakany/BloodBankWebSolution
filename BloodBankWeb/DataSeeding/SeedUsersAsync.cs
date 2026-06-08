using Microsoft.AspNetCore.Identity;

namespace BloodBankWeb.DataSeeding
{
    public static class SeedUsersAsync
    {
        public static async Task AppAdmin(UserManager<ApplicationUser> userManager)
        {
            ApplicationUser admin = new()
            {
                UserName = "admin",
                Email = "admin@bloodBank.com",
                FullName = "Admin",
                NationalId = "23423423433343",
                BloodTypeId = 8,
                PhoneNumber = "01096710329",
                EmailConfirmed = true,
                Age = 30,
                BloodBankId = 49,
                CityId = 3
                

            };

            var user = await userManager.FindByEmailAsync(admin.Email);

            if (user is null) 
            {
            await userManager.CreateAsync(admin , "P@ssword123");
            await userManager.AddToRoleAsync(admin , AppRoles.Admin);
            await userManager.AddToRoleAsync(admin , AppRoles.subAdmin);
            }


        }



    }
}
