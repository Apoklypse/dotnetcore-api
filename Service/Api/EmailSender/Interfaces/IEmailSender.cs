using Api.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Api.EmailSender
{
    public interface IEmailSender
    {
        void SendEmail(Email email);
    }
}
