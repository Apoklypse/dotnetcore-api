using Domain.Core;
using System;

namespace Services.EmailService
{
    public class EmailService : IEmailService
    {
        public void SendEmail(Email email)
        {
            var recipientString = "";
            email.Recipients.ForEach(recipient =>
            {
                recipientString += $"{ recipient } ";
            });

            Console.WriteLine($"Sending email to { recipientString }");
        }
    }
}