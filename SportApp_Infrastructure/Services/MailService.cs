using MailKit.Security;
using Microsoft.Extensions.Configuration;
using MimeKit;
using SportApp_Infrastructure.Model.Mail;
using SportApp_Infrastructure.Services.Interfaces;
using MailKit.Net.Smtp;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SportApp_Infrastructure.Services
{
    public class MailService : IMailService
    {
        private readonly IConfiguration _configuration;

        public MailService(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        public async Task<bool> SendEmail(MailRequest request)
        {
            var email = new MimeMessage();
            email.From.Add(MailboxAddress.Parse(_configuration["EmailSetting:Email"]));
            email.To.Add(MailboxAddress.Parse(request.ToEmail));
            email.Subject = request.Subject;
            var builder = new BodyBuilder();
            builder.HtmlBody = request.Body;
            email.Body = builder.ToMessageBody();

            using var smtp = new SmtpClient();
            smtp.Connect(_configuration["EmailSetting:Host"], 587, SecureSocketOptions.StartTls);
            smtp.Authenticate(_configuration["EmailSetting:Email"], _configuration["EmailSetting:Password"]);
            smtp.Send(email);
            smtp.Disconnect(true);

            return await Task.FromResult(true);

        }
    }
}
