﻿using Domain.Core;

namespace Services.EmailService
{
    public interface IEmailService
    {
        void SendEmail(EmailMessage message);
    }
}
