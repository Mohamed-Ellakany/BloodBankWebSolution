# BloodBank

Blood bank management system built as my BSc graduation project with ASP.NET Core. It has a REST API and an MVC admin web app on top of a shared application layer.

## What it does
- Tracks blood bags, plasma and platelets by blood bank and blood type
- Donors, donor banks, cities and reservations
- Community posts
- Registration with email OTP confirmation, JWT login, forgot and reset password, profile update
- AI endpoints for blood recommendation and disease-based prediction, which call an external model service (`AIModel:ApiUrl`)
- Real-time chat through a SignalR hub
- Background email jobs with Hangfire (dashboard at `/Jobs`, basic auth)
- Roles: Admin, subAdmin, User

## Tech stack
C#, ASP.NET Core (.NET 10), Entity Framework Core, SQL Server, ASP.NET Identity, JWT, SignalR, Hangfire, FluentValidation, Mapster, AutoMapper, Serilog, Swagger, MailKit, Polly

## Structure
```
BloodBank.Domain          entities and constants
BloodBank.Application     services, DTOs, JWT, result pattern
BloodBank.Infrastructure  EF Core DbContext, repositories, unit of work, migrations
BloodBank.Api             REST API, SignalR hub, Hangfire
BloodBankWeb              MVC admin web app
```

## Run locally
Requires the .NET 10 SDK and SQL Server (LocalDB is the default in `appsettings.json`).

1. Set these values with user secrets or `appsettings.Development.json`: the `Jwt` section, `EmailSettings` (Host, Port, Email, Password), `HangfireSettings` (UserName, Password) and `AIModel:ApiUrl`.
2. Create the database:
   `dotnet ef database update --project BloodBank.Infrastructure --startup-project BloodBank.Api`
3. Start the API: `dotnet run --project BloodBank.Api`
4. Start the admin web app: `dotnet run --project BloodBankWeb`

The AI endpoints only work when the separate model service at `AIModel:ApiUrl` is running.
