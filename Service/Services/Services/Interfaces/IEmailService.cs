using Domain.Core;

namespace Services.EmailSender
{
    public interface IEmailService
    {
        void SendEmail(Email email);
    }
}
