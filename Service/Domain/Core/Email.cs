using System.Collections.Generic;

namespace Domain.Core
{
    public class EmailMessage
    {
        public List<string> Recipients { get; set; }

        public string Subject { get; set; }

        public string Content { get; set; }
    }
}
