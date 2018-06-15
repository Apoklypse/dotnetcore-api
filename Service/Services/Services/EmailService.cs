using Domain.Core;
using System;

namespace Services.EmailSender
{
    public class EmailSender : IEmailService
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