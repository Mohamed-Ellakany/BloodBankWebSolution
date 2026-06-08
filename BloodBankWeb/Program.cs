using BloodBankWeb.DataSeeding;
using BloodBankWeb.Helpers;
using BloodBankWeb.Mapping;
using Microsoft.AspNetCore.Identity;
using Serilog;
using UoN.ExpressiveAnnotations.NetCore.DependencyInjection;
using BloodBank.Infrastructure;
using BloodBank.Application.Services.Blood;
using BloodBank.Application.Services.Donors;
using BloodBank.Application.Services.BloodTypes;
using BloodBank.Application.Services.BloodBanks;
using BloodBank.Application.Services.Home;
using BloodBank.Application.Services.Plasmas;
using BloodBank.Application.Services.Plateletses;
using BloodBank.Application.Services.DonorBanks;

namespace BloodBankWeb
{
    public class Program
    {
        public static  async Task Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // Add services to the container.
            builder.Services.AddInfrastructureServices(builder.Configuration);

            builder.Services.AddDashboardDependancies(builder.Configuration);


            builder.Services.AddControllersWithViews();

            builder.Services.AddAutoMapper(_ => { }, typeof(MappingProfiles).Assembly);

            builder.Services.AddExpressiveAnnotations();

            //serilog
            Log.Logger=new LoggerConfiguration().ReadFrom.Configuration(builder.Configuration).CreateLogger(); 
            builder.Host.UseSerilog();

            var app = builder.Build();

            // Configure the HTTP request pipeline.
            if (app.Environment.IsDevelopment())
            {
                app.UseMigrationsEndPoint();
            }
            else
            {
                app.UseExceptionHandler("/Home/Error");
                // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
                app.UseHsts();
            }

            app.UseHttpsRedirection();
            app.MapStaticAssets();
            app.UseRouting();

            app.UseAuthentication();
            app.UseAuthorization();

            var scopeFactory = app.Services.GetRequiredService<IServiceScopeFactory>();
            using var scope = scopeFactory.CreateScope();
            var db = scope.ServiceProvider.GetService<ApplicationDbContext>();

            var roleManager = scope.ServiceProvider.GetRequiredService<RoleManager<IdentityRole>>();
            var userManager = scope.ServiceProvider.GetRequiredService<UserManager<ApplicationUser>>();
           
             await SeedCities.SeedingCities(db);
            
            await SeedData.SeedingData(db);

            await SeedBloodBanks.SeedingBloodBanks(db);


            await SeedRolesAsync.seedRoles(roleManager);

            await SeedUsersAsync.AppAdmin(userManager);

            await SeedBloodBags.SeedAsync(db);
            
          

            app.MapControllerRoute(
                name: "default",
                pattern: "{controller=Home}/{action=Index}/{id?}");
            app.MapRazorPages();

            app.Run();
        }
    }
}
