﻿using balasolu.models.options;
using balasolu.services.interfaces;
using Serilog;
using System.Net;
using System.Net.Mail;

namespace balasolu.services
{
    sealed class EmailService : IEmailService
    {
        readonly SmtpOptions _options;

        public EmailService(
            SmtpOptions options)
        {
            _options = options;
        }

        public async Task SendEmailAsync(string recipient, string subject, string body)
        {
            try
            {
                using var smtpClient = new SmtpClient()
                {
                    Host = _options.Host.Trim(),
                    Port = int.TryParse(_options.Port, out var port) ? port : 465,
                    EnableSsl = true,
                    UseDefaultCredentials = false,
                    Credentials = new NetworkCredential(_options.Username.Trim(), _options.Password.Trim()),
                    DeliveryMethod = SmtpDeliveryMethod.Network
                };
                using var message = new MailMessage(_options.FromAddress.Trim(), recipient)
                {
                    From = new MailAddress(_options.FromAddress.Trim(), _options.FromName.Trim()),
                    Subject = subject,
                    Body = body,
                    IsBodyHtml = true
                };
                await smtpClient.SendMailAsync(message);
            }
            catch (Exception e)
            {
                Log.Error(e.Message);
            }
        }
    }
}