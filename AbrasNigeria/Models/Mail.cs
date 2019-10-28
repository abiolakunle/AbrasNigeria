namespace AbrasNigeria.Models
{
    public class Mail
    {
        public string Address { get; set; }

        public string Subject { get; set; }

        public string Message { get; set; }

        public long AttachmentId { get; set; }
    }
}
