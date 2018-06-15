using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Api.Domain;

namespace Api.EmailSender
{
    public class EmailSender : IEmailSender
    {
        public void SendEmail(Email email)
        {
            var recipientString = "";
            email.Recipients.ForEach(recipient => {
                recipientString += $"{ recipient } ";
            });

            Console.WriteLine($"Sending email to { recipientString }");
        }
    }
}
