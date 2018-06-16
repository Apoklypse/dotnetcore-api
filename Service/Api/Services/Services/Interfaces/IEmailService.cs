using Domain.Core;

namespace Services.EmailService
{
    public interface IEmailService
    {
        bool SendEmail(EmailMessage message);
    }
}
