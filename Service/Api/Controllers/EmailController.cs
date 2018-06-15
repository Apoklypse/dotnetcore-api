using System.Collections.Generic;
using Domain.Core;
using Microsoft.AspNetCore.Mvc;
using Services.EmailService;

namespace Api.Controllers
{
    [Route("api/[controller]")]
    public class EmailController : Controller
    {
        private readonly IEmailService emailSender;

        public EmailController(IEmailService emailSender)
        {
            this.emailSender = emailSender;
        }
        
        [HttpGet]
        public IEnumerable<string> Get()
        {
            this.emailSender.SendEmail(new EmailMessage
            {
                Recipients = new List<string> { "recipient@address.com", "recipient@address.com" },
                Subject = "Subject",
                Content = "Content",
            });
            return new string[] { "value1", "value2" };
        }
        
        [HttpGet("{id}")]
        public string Get(int id)
        {
            return "value";
        }
        
        [HttpPost]
        public void Post([FromBody]string value)
        {
        }
    }
}
