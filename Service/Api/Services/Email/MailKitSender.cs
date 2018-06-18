using MailKit.Net.Smtp;
using MimeKit;
using Serilog;
using System;

namespace Services.Email
{
    public class MailKitSender : IEmailSender
    {
        private readonly ILogger logger;

        public MailKitSender(ILogger loggerParam)
        {
            this.logger = loggerParam ?? throw new ArgumentNullException(nameof(loggerParam));
        }

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

                    this.logger.Debug($"Sending Email");
                    client.Send(message);
                }
                catch (Exception ex)
                {
                    this.logger.Error(ex, "An error occurred: ");
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