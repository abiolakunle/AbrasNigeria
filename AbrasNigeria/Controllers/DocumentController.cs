using System;
using System.Collections.Generic;
using AbrasNigeria.Data.DTO;
using AbrasNigeria.Data.Interfaces;
using AbrasNigeria.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MailKit.Net.Smtp;
using MimeKit;
using System.IO;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace AbrasNigeria.Controllers
{
    [Authorize]
    [Route("api/[controller]")]
    public class DocumentController : Controller
    {
        private readonly IDocumentRepository _documentRepository;

        public DocumentController(IDocumentRepository documentRepository)
        {
            _documentRepository = documentRepository;
        }

        [HttpGet("[action]")]
        public IEnumerable<Document> Documents()
        {
            return _documentRepository.LoadAllWithItems();
        }

        // GET api/<controller>/5
        [HttpGet("[action]")]
        public DocumentDTO Document(int id)
        {
            return _documentRepository.LoadWithItems(id);
        }

        // POST api/<controller>
        [HttpPost("[action]")]
        public ActionResult Create([FromBody]Document document)
        {
            //I NEED TO WRITE A FUNCTIONALITY TO HANDLES VALIDIATION OF MODEL STATE FOR ALL ACTION METHODS
            if (ModelState.IsValid)
            {
                document.DocumentNo = "AN" + document.DocumentType.Substring(0, 1) + DateTime.Now.ToString("yyMMddHHmmss");
                _documentRepository.Create(document);
                return Ok();
            }
            return BadRequest(ModelState);

        }

        [HttpPut("[action]")]
        public ActionResult UpdateDocument([FromBody]Document document)
        {
            _documentRepository.Update(document);
            return Ok();
        }

        [AllowAnonymous]
        [HttpPost("[action]")]
        public ActionResult Send(IFormFile document)
        {
            if (document == null || document.Length == 0)
            {
                return BadRequest();
            }
            else
            {
                SendMail(document);
                return Ok();
            }
        }

        [HttpDelete("[action]")]
        public ActionResult Delete(int id)
        {
            Document document = _documentRepository.GetById(id);

            _documentRepository.Delete(document);

            return Ok();
        }

        [NonAction]
        public void SendMail(IFormFile document)
        {
            using (var reader = new StreamReader(document.OpenReadStream()))
            {
                var attachment = new MimePart(document.ContentType, "application/pdf")
                {
                    Content = new MimeContent(reader.BaseStream),
                    ContentDisposition = new ContentDisposition(ContentDisposition.Attachment),
                    ContentTransferEncoding = ContentEncoding.Base64,
                    FileName = Path.GetFileName(document.FileName)
                };

                //Prepare an email message to be sent
                MimeMessage message = new MimeMessage();

                MailboxAddress from = new MailboxAddress("Olakunle", "olakunle2abiola@gmail.com");
                message.From.Add(from);

                MailboxAddress to = new MailboxAddress("Abras",
                "olakunle2abiola@gmail.com");
                message.To.Add(to);

                message.Subject = $"{document.FileName}";

                //Add email body and file attachments
                BodyBuilder bodyBuilder = new BodyBuilder
                {
                    HtmlBody = $"<h1>{document.FileName}</h1>",
                };
                bodyBuilder.Attachments.Add(attachment);

                message.Body = bodyBuilder.ToMessageBody();

                //Connect and authenticate with the SMTP server
                SmtpClient client = new SmtpClient();
                client.Connect("smtp.gmail.com", 587, false);

                //In a nutshell, google is not allowing you to log in via smtplib because it has flagged this sort of login as "less secure", so what you have to do is go to this link while you're logged in to your google account, and allow the access:
                //https://myaccount.google.com/lesssecureapps
                client.Authenticate("abiola2olakunle@gmail.com", "W@p@1993");

                //Send email message
                client.Send(message);
                client.Disconnect(true);
                client.Dispose();
            }
        }
    }
}
