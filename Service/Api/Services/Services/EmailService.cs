using Domain.Core;
using MimeKit;
using Serilog;
using Services.Email;
using System;

namespace Services.EmailService
{
    public class EmailService : IEmailService
    {
        private readonly ILogger logger;
        private readonly IEmailSender mailSender;

        public EmailService(
            ILogger loggerParam,
            IEmailSender mailSenderParam)
        {
            this.logger = loggerParam ?? throw new ArgumentNullException(nameof(loggerParam));
            this.mailSender = mailSenderParam ?? throw new ArgumentNullException(nameof(mailSenderParam));
        }

        public bool SendEmail(EmailMessage emailParam)
        {
            var email = emailParam ?? throw new ArgumentNullException(nameof(emailParam));


            this.logger.Verbose($"Preparing to send email to { email.RecipientAddress }: { email.Content }");
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