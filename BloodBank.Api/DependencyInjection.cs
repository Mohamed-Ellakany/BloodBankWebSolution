using BloodBank.Application.Services.AuthServices;
using Hangfire;
using BloodBank.Application.Services.Users;
using BloodBank.Application.Services.Email;
using Microsoft.AspNetCore.Identity.UI.Services;
using BloodBank.Application.Services.BloodTypes;
using BloodBank.Application.Services.Donors;
using BloodBank.Application.Services.BloodBanks;
using BloodBank.Application.Services.Blood;
using BloodBank.Application.Services.Plasmas;
using BloodBank.Application.Services.Plateletses;
using BloodBank.Application.Services.Community;
using BloodBank.Application.Services.Reservation;
using BloodBank.Application.Services.City;
using BloodBank.Application.Services.AI;
using BloodBank.Application.Services.AiServices;


namespace BloodBank.Api
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddDependencies(this IServiceCollection services , IConfiguration configuration)
        {


            services.AddControllers();


            services.AddSwaggerDependencies();

            services.AddHttpClient("predictApi", client =>
            {
                client.BaseAddress = new Uri("https://sohailaashraf.pythonanywhere.com/");
                client.DefaultRequestHeaders.Add("Accept", "application/json");

            });

         
            services.AddHttpClient("RecommendedApi", client =>
            {
                client.BaseAddress = new Uri("https://sohailamohamed.pythonanywhere.com/");
                client.DefaultRequestHeaders.Add("Accept", "application/json");
                
            }) ;

            services.AddMemoryCache();

            services.AddMapsterDependencies();

            services.AddFluentValidationDependencies();

            services.AddIdentityDependencies(configuration);

            services.AddJobsDependencies(configuration);

            services.AddExceptionHandler<GlobalExceptionHandler>();

            services.AddProblemDetails();

            services.AddHttpContextAccessor();

            services.AddScoped<IUserService, UserService>();

            services.AddScoped<IEmailSender, EmailService>();

            services.AddScoped<IUnitOfWork , UnitOfWork>();

            services.AddScoped<IBloodSevrice , BloodSevrice>();

            services.AddScoped<IPlasmaService , PlasmaService>();

            services.AddScoped<IPlateletsService , PlateletsService>();

            services.AddScoped<IBloodTypesServices, BloodTypesServices>();

            services.AddScoped<IReservationService, ReservationService>();

            services.AddScoped < IDonorsServices, DonorsServices > ();

            services.AddScoped < IBloodBankServices, BloodBankServices> ();

            services.AddScoped < IPostServices, PostServices> ();

            services.AddScoped<ICityServices, CityServices>();

            services.AddScoped<IAiServices, AiServices>();

            return services;
        }



        private static IServiceCollection AddSwaggerDependencies(this IServiceCollection services)
        {
         
            services.AddEndpointsApiExplorer();
            services.AddSwaggerGen();


            return services;
        }


        private static IServiceCollection AddFluentValidationDependencies(this IServiceCollection services)
        {

            services.AddValidatorsFromAssemblyContaining<Program>();
            services.AddFluentValidationAutoValidation();


            return services;
        }
        

         private static IServiceCollection AddMapsterDependencies(this IServiceCollection services)
        {
         
            var mappingConfig = TypeAdapterConfig.GlobalSettings;
            mappingConfig.Scan(Assembly.GetExecutingAssembly());


            services.AddSingleton<IMapper>(new Mapper(mappingConfig));


            return services;
        }


        private static IServiceCollection AddIdentityDependencies(this IServiceCollection services , IConfiguration configuration)
        {


            services.AddScoped<IAuthService, AuthService>();
            services.AddSingleton<IJwtProvider, JwtProvider>();
            services.AddScoped<IApplicationDbContext>(provider => provider.GetRequiredService<ApplicationDbContext>());

            // services.Configure<JwtOptions>(configuration.GetSection(JwtOptions.SectionName));

            services.AddOptions<JwtOptions>()
                .BindConfiguration(JwtOptions.SectionName)
                .ValidateDataAnnotations()
                .ValidateOnStart();

            var JwtSettings = configuration.GetSection(JwtOptions.SectionName).Get<JwtOptions>();

            services.AddIdentity<ApplicationUser, IdentityRole>()
                .AddEntityFrameworkStores<ApplicationDbContext>()
                .AddDefaultTokenProviders();

            services.AddAuthentication(options =>
            {
                options.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
                options.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
            }).AddJwtBearer(o =>
            {
                o.SaveToken = true;
                o.TokenValidationParameters = new TokenValidationParameters
                {
                    ValidateIssuerSigningKey = true,
                    ValidateIssuer = true,
                    ValidateAudience = true,
                    ValidateLifetime = true,
                    IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(JwtSettings?.Key!)),
                    ValidIssuer =JwtSettings?.Issure,
                    ValidAudience = JwtSettings?.Audience
                };
            });

            services.Configure<IdentityOptions>(options =>
            {
                options.Password.RequiredLength = 8;
                options.SignIn.RequireConfirmedEmail = true;
                options.User.RequireUniqueEmail = true;

            });

            return services;
        }


        private static IServiceCollection AddJobsDependencies(this IServiceCollection services , IConfiguration configuration)
        {

            services.AddHangfire(config => config
                     .SetDataCompatibilityLevel(CompatibilityLevel.Version_180)
                     .UseSimpleAssemblyNameTypeSerializer()
                     .UseRecommendedSerializerSettings()
                     .UseSqlServerStorage(configuration.GetConnectionString("HangfireConnection")));

            services.AddHangfireServer();



            return services;
        }


    }
}
