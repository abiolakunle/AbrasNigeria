using MimeKit;
using System.Collections.Generic;

namespace AbrasNigeria.Data.Services
{
    public interface IMailTemplate
    {
        void AddToAddress(string address);

        void AddToAddressList(IEnumerable<string> mailboxAddresses);

        void AddFromAddress(string address);

        void AddFromAddressList(IEnumerable<string> mailboxAddresses);

        void SetMailSubject(string subject);

        void AddAttachment(MimePart attachment);
        void AddAttachmentList(IEnumerable<MimePart> attachments);

        void SetMailBody(string mailBody);
        MimeMessage GetMessage();
    }
}