using Hangfire;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Http.Connections;
using BloodBank.Api.ChatAi;
using HangfireBasicAuthenticationFilter;
using Serilog;
namespace BloodBank.Api
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // Add services to the container.

            builder.Services.AddDbContext<ApplicationDbContext>(options =>
                    options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")), ServiceLifetime.Scoped);

            builder.Services.AddDependencies(builder.Configuration);

            builder.Services.AddControllers();

            builder.Services.AddSignalR();


            builder.Services.AddCors(options =>
            {
                options.AddPolicy("AllowAll", policy =>
                {
                    policy.AllowAnyOrigin()  
                          .AllowAnyMethod()
                          .AllowAnyHeader();
                });
            });

            builder.Services.AddHttpClient<AIModelService>(client =>
            {
                client.BaseAddress = new Uri(builder.Configuration["AIModel:ApiUrl"]!);
            });

            //serilog
            Log.Logger = new LoggerConfiguration().ReadFrom.Configuration(builder.Configuration).CreateLogger();
            builder.Host.UseSerilog();

            var app = builder.Build();

            app.UseExceptionHandler();

            app.UseCors("AllowAll");


            // Configure the HTTP request pipeline.
            if (app.Environment.IsDevelopment())
            {
                app.UseSwagger();
                app.UseSwaggerUI();
               

            }

            app.UseHangfireDashboard("/Jobs", new DashboardOptions
            {
                Authorization =
                [
                    new HangfireCustomBasicAuthenticationFilter
                    {
                        User = app.Configuration.GetValue<string>("HangfireSettings:UserName"),
                        Pass =app.Configuration.GetValue<string>("HangfireSettings:Password"),
                    }
                    ]
,
                DashboardTitle = "Blood Bank Jobs",
                IgnoreAntiforgeryToken = true
            }

            );


            app.UseHttpsRedirection();

            app.UseAuthorization();

            app.MapControllers();

            app.UseWebSockets();


            app.MapHub<ChatHub>("/chatHub", options =>
            {
                options.Transports = HttpTransportType.WebSockets | HttpTransportType.LongPolling;
                options.WebSockets.CloseTimeout = TimeSpan.FromSeconds(30);
            }).RequireCors("AllowAll"); ;





            app.Run();
        }
    }
}
