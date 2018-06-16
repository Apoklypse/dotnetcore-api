namespace Domain.Core
{
    public class EmailMessage
    {
        public string RecipientAddress { get; set; }

        public string SenderAddress { get; set; }

        public string Subject { get; set; }

        public string Content { get; set; }
    }
}