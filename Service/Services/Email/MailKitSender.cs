using MailKit.Net.Smtp;
using MimeKit;

namespace Services.Email
{
    public class MailKitSender : IEmailSender
    {
        public void Send()
        {
            var message = new MimeMessage();
            message.From.Add(new MailboxAddress("name@domain.com"));
            message.To.Add(new MailboxAddress("name@domain.com"));
            message.Subject = "Subject";

            message.Body = new TextPart("plain")
            {
                Text = "Body",
            };

            using (var client = new SmtpClient())
            {
                client.ServerCertificateValidationCallback = (s, c, h, e) => true;

                client.Connect("localhost", 25, false);

                //client.Authenticate("username", "password");

                client.Send(message);
                client.Disconnect(true);
            }
        }
    }
}
