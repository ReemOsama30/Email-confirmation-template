﻿using System.Net;
using System.Net.Mail;

namespace WebApplication1.services
{
    public class EmailService : IEmailService
    {
        private readonly IConfiguration _config;

        public EmailService(IConfiguration config)
        {
            _config = config;
        }

        public Task SendEmailAsync(string toEmail, string subject, string body, bool isBodyHTML)
        {
            string mailServer = _config["EmailSettings:MailServer"];
            string fromEmail = _config["EmailSettings:FromEmail"];
            string password = _config["EmailSettings:Password"];
            int port = int.Parse(_config["EmailSettings:MailPort"]);

            var client = new SmtpClient(mailServer, port)
            {
                Credentials = new NetworkCredential(fromEmail, password),
                EnableSsl = true,
            };

            var mailMessage = new MailMessage(fromEmail, toEmail, subject, body)
            {
                IsBodyHtml = isBodyHTML
            };

            return client.SendMailAsync(mailMessage);
        }
    }

}
