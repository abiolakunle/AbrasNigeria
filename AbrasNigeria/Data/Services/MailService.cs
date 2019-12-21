using MailKit.Net.Smtp;

namespace AbrasNigeria.Data.Services
{
    public class MailService
    {
        private readonly SmtpClient _client;
        private readonly IMailTemplate _template;

        public MailService(IMailTemplate template)
        {
            _client = new SmtpClient();
            _template = template;
        }

        private void ConfigureClient()
        {
            //Connect and authenticate with the SMTP server
            _client.Connect("smtp.gmail.com", 587, false);

            //In a nutshell, google is not allowing you to log in via smtplib because it has flagged this sort of login as "less secure", so what you have to do is go to this link while you're logged in to your google account, and allow the access:
            //https://myaccount.google.com/lesssecureapps
            _client.Authenticate("abiola2olakunle@gmail.com", "W@p@1993");
        }

        public void SendMail()
        {
            //Send email message
            ConfigureClient();
            _client.Send(_template.GetMessage());
            CleanUp();
        }

        private void CleanUp()
        {
            _client.Disconnect(true);
            _client.Dispose();
        }
    }
}
