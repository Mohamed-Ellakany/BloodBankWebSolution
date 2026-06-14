using MailKit.Security;
using Microsoft.AspNetCore.Identity.UI.Services;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;
using MimeKit;
using MailKit.Net.Smtp;

namespace BloodBank.Application.Services.Email
{
    public class EmailService(IConfiguration configuration , ILogger<EmailService> logger) : IEmailSender
    {
        private readonly IConfiguration _configuration = configuration;



        private readonly ILogger<EmailService> _logger = logger;

     

        public async Task SendEmailAsync(string email, string subject, string htmlMessage)
        {
            var Email = _configuration.GetValue<string>("EmailSettings:Email")
                ?? throw new InvalidOperationException("Email setting 'EmailSettings:Email' is missing.");
            var Password = _configuration.GetValue<string>("EmailSettings:Password")
                ?? throw new InvalidOperationException("Email setting 'EmailSettings:Password' is missing.");
            var Host = _configuration.GetValue<string>("EmailSettings:Host")
                ?? throw new InvalidOperationException("Email setting 'EmailSettings:Host' is missing.");
            var Port = _configuration.GetValue<int>("EmailSettings:Port");


            var message = new MimeMessage
            {
                Sender = MailboxAddress.Parse(Email),
                Subject = subject
            };

            message.To.Add(MailboxAddress.Parse(email));

            var builder = new BodyBuilder
            {
                HtmlBody = htmlMessage
            };

            message.Body = builder.ToMessageBody();

            using var smtp = new SmtpClient();

            _logger.LogInformation("Sending email to {email}", email);

            smtp.Connect(Host, Port, SecureSocketOptions.StartTls);
            smtp.Authenticate(Email, Password);
            await smtp.SendAsync(message);
            smtp.Disconnect(true);
        }

    }
}

