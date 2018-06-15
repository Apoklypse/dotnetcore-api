using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Api.Domain
{
    public class Email
    {
        public List<string> Recipients { get; set; }

        public string Subject { get; set; }

        public string Content { get; set; }
    }
}
