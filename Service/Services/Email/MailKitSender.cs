using MailKit.Net.Smtp;
using MimeKit;
using System;
using System.Linq;

namespace Services.Email
{
    public class MailKitSender : IEmailSender
    {
        public bool Send(MimeMessage messageParam)
        {
            var message = messageParam ?? throw new ArgumentNullException(nameof(messageParam));

            using (var client = new SmtpClient())
            {
                client.ServerCertificateValidationCallback = (s, c, h, e) => true;

                try
                {
                    client.Connect("localhost", 25, false);

                    //client.Authenticate("username", "password");

                    Console.WriteLine($"Sending message to { message.To.FirstOrDefault() }");
                    client.Send(message);
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex);
                    return false;
                }
                finally
                {
                    client.Disconnect(true);
                }

                return true;
            }
        }
    }
}
