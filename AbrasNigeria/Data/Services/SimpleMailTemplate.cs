using System;
using System.Collections.Generic;
using MimeKit;

namespace AbrasNigeria.Data.Services
{
    public class SimpleMailTemplate : IMailTemplate
    {
        private readonly MimeMessage _message;
        private readonly BodyBuilder _bodyBuilder;

        public SimpleMailTemplate()
        {
            _message = new MimeMessage();
            _bodyBuilder = new BodyBuilder();
        }

        public void AddToAddress(string address)
        {
            MailboxAddress mailboxAddress = new MailboxAddress(address);
            _message.To.Add(mailboxAddress);
        }

        public void AddToAddressList(IEnumerable<string> mailboxAddresses)
        {
            _message.To.AddRange(ToAddressList(mailboxAddresses));
        }

        public void SetMailBody(string mailBody)
        {
            _bodyBuilder.HtmlBody = mailBody;
        }

        public MimeMessage GetMessage()
        {
            _message.Body = _bodyBuilder.ToMessageBody();
            return _message;
        }

        public void AddFromAddress(string address)
        {
            MailboxAddress from = new MailboxAddress(address);
            _message.From.Add(from);
        }

        public void AddFromAddressList(IEnumerable<string> mailboxAddresses)
        {
            _message.From.AddRange(ToAddressList(mailboxAddresses));
        }

        private IEnumerable<MailboxAddress> ToAddressList(IEnumerable<string> mailboxAddresses)
        {
            List<MailboxAddress> addresses = new List<MailboxAddress>();

            foreach (var address in mailboxAddresses)
            {
                addresses.Add(new MailboxAddress(address));
            }
            return addresses;
        }

        public void SetMailSubject(string subject)
        {
            _message.Subject = subject;
        }

        public void AddAttachment(MimePart attachment)
        {
            _bodyBuilder.Attachments.Add(attachment);
        }

        public void AddAttachmentList(IEnumerable<MimePart> attahcments)
        {
            foreach (var attachment in attahcments)
            {
                _bodyBuilder.Attachments.Add(attachment);
            }
        }
    }
}
