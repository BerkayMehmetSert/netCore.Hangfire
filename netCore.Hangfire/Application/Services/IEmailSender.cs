﻿namespace netCore.Hangfire.Application.Services
{
    public interface IEmailSender
    {
        void SendEmail(string[] email, string subject, string message);
    }
}
