﻿namespace balasolu.services.interfaces
{
    public interface IEmailService
    {
        Task SendEmailAsync(string recipient, string subject, string body);
    }
}
