using Domain.Core;
using System;

namespace Services.EmailService
{
    public class EmailService : IEmailService
    {
        public void SendEmail(EmailMessage message)
        {
            var recipientString = "";
            message.Recipients.ForEach(recipient =>
            {
                recipientString += $"{ recipient } ";
            });

            Console.WriteLine($"Sending email to { recipientString }");
        }
    }
}