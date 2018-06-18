using MimeKit;

namespace Services.Email
{
    public interface IEmailSender
    {
        bool Send(MimeMessage messageParam);
    }
}