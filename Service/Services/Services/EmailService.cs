using Domain.Core;
using MimeKit;
using Services.Email;
using System;

namespace Services.EmailService
{
    public class EmailService : IEmailService
    {
        private readonly IEmailSender mailSender;

        public EmailService(IEmailSender mailSenderParam)
        {
            this.mailSender = mailSenderParam ?? throw new ArgumentNullException(nameof(mailSenderParam));
        }

        public bool SendEmail(EmailMessage emailParam)
        {
            var email = emailParam ?? throw new ArgumentNullException(nameof(emailParam));

            var message = new MimeMessage();

            message.From.Add(new MailboxAddress(email.SenderAddress));
            message.To.Add(new MailboxAddress(email.RecipientAddress));
            message.Subject = email.Subject;

            message.Body = new TextPart("plain")
            {
                Text = email.Content,
            };

            return this.mailSender.Send(message);
        }
    }
}