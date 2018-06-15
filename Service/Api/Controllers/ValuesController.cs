using System.Collections.Generic;
using Domain.Core;
using Microsoft.AspNetCore.Mvc;
using Services.EmailSender;

namespace Api.Controllers
{
    [Route("api/[controller]")]
    public class ValuesController : Controller
    {
        private readonly IEmailService emailSender;

        public ValuesController(IEmailService emailSender)
        {
            this.emailSender = emailSender;
        }

        // GET api/values
        [HttpGet]
        public IEnumerable<string> Get()
        {
            return new string[] { "value1", "value2" };
        }

        // GET api/values/5
        [HttpGet("{id}")]
        public string Get(int id)
        {
            this.emailSender.SendEmail(new Email {
                Recipients = new List<string> { "recipient@address.com", "recipient@address.com" },
                Subject = "Subject",
                Content = "Content",
            });
            return "value";
        }

        // POST api/values
        [HttpPost]
        public void Post([FromBody]string value)
        {
        }

        // PUT api/values/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody]string value)
        {
        }

        // DELETE api/values/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
