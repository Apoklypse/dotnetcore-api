using System.Collections.Generic;
using Domain.Core;
using Microsoft.AspNetCore.Mvc;
using Services.EmailService;

namespace Api.Controllers
{
    [Route("api/[controller]")]
    public class EmailController : Controller
    {
        private readonly IEmailService emailService;

        public EmailController(IEmailService emailServiceParam)
        {
            this.emailService = emailServiceParam;
        }
        
        [HttpGet]
        public IActionResult Get()
        {
            var result = this.emailService.SendEmail(new EmailMessage
            {
                SenderAddress = "sender@address.com",
                RecipientAddress = "recipient@address.com",
                Subject = "Subject",
                Content = "Content",
            });

            return new JsonResult(result);
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
