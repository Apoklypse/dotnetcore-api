using Domain.Core;
using Microsoft.AspNetCore.Mvc;
using Serilog;
using Services.EmailService;
using System;

namespace Api.Controllers
{
    [Route("api/[controller]")]
    public class EmailController : Controller
    {
        private readonly IEmailService emailService;
        private readonly ILogger logger;

        public EmailController(
            ILogger loggerParam,
            IEmailService emailServiceParam)
        {
            this.logger = loggerParam ?? throw new ArgumentNullException(nameof(loggerParam));
            this.emailService = emailServiceParam ?? throw new ArgumentNullException(nameof(emailServiceParam));
        }

        [HttpGet]
        public IActionResult Get()
        {
            return new OkResult();
        }

        [HttpGet("{id}")]
        public IActionResult Get(int id)
        {
            return new OkResult();
        }

        [HttpPost]
        public IActionResult Post([FromBody]EmailMessage messageParam)
        {
            var message = messageParam ?? throw new ArgumentNullException(nameof(messageParam));

            this.logger.Verbose($"{ nameof(EmailController) } GET");
            var result = this.emailService.SendEmail(message);

            return new JsonResult(result);
        }
    }
}