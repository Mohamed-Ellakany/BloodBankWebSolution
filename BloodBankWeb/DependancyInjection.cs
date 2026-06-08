using BloodBank.Application.Services.Blood;
using BloodBank.Application.Services.BloodBanks;
using BloodBank.Application.Services.BloodTypes;
using BloodBank.Application.Services.City;
using BloodBank.Application.Services.DonorBanks;
using BloodBank.Application.Services.Donors;
using BloodBank.Application.Services.Home;
using BloodBank.Application.Services.Plasmas;
using BloodBank.Application.Services.Plateletses;
using BloodBankWeb.Helpers;
using Microsoft.AspNetCore.Identity;

namespace BloodBankWeb
{
    public  static class DependancyInjection
    {
        public static IServiceCollection AddDashboardDependancies(this IServiceCollection services, IConfiguration configuration)
        {

            var connectionString = configuration.GetConnectionString("DefaultConnection") ?? throw new InvalidOperationException("Connection string 'DefaultConnection' not found.");


            services.AddIdentity<ApplicationUser, IdentityRole>(options => options.SignIn.RequireConfirmedAccount = true)
                .AddEntityFrameworkStores<ApplicationDbContext>()
                .AddDefaultUI()
                .AddDefaultTokenProviders();


            services.Configure<IdentityOptions>(opt =>
            {
                opt.User.RequireUniqueEmail = true;
            });

            services.Configure<SecurityStampValidatorOptions>(opt => opt.ValidationInterval = TimeSpan.Zero);

            services.AddScoped<IUserClaimsPrincipalFactory<ApplicationUser>, ApplicationUserClaimsPrincipalFactory>();

            services.AddScoped<IUnitOfWork, UnitOfWork>();
            services.AddScoped<IBloodSevrice, BloodSevrice>();
            services.AddScoped<IPlasmaService, PlasmaService>();
            services.AddScoped<IPlateletsService, PlateletsService>();
            services.AddScoped<IDonorsServices, DonorsServices>();
            services.AddScoped<IBloodTypesServices, BloodTypesServices>();
            services.AddScoped<IBloodBankServices, BloodBankServices>();
            services.AddScoped<IDonorBanksServices, DonorBanksServices>();
            services.AddScoped<IHomeService, HomeService>();
            services.AddScoped<ICityServices, CityServices>();

            return services;

        }


    }
}
