using AbrasNigeria.Data.Interfaces;
using AbrasNigeria.Models;
using Microsoft.AspNetCore.Mvc;
using System;
using MailKit.Net.Smtp;
using MimeKit;

namespace AbrasNigeria.Controllers
{
    [Route("api/[controller]")]
    public class OrderController : Controller
    {
        private readonly IOrderRepository _orderRepository;

        public OrderController(IOrderRepository orderRepository)
        {
            _orderRepository = orderRepository;
        }

        [HttpPost("[action]")]
        public ActionResult AddOrder([FromBody]Order order)
        {
            SendMail(order);

            //set order date and number

            order.OrderNo = "CAN" + DateTime.Now.ToString("yyMMddHHmmss");

            _orderRepository.Create(order);
            return Ok();
        }

        [NonAction]
        public void SendMail(Order order)
        {
            //set order date
            order.Date = DateTime.Now;

            //Prepare an email message to be sent
            MimeMessage message = new MimeMessage();

            MailboxAddress from = new MailboxAddress(order.CompanyName,
            order.Email);
            message.From.Add(from);

            MailboxAddress to = new MailboxAddress("Abras",
            "olakunle2abiola@gmail.com");
            message.To.Add(to);

            message.Subject = $"{order.CompanyName} Quotation request - {order.Date}";

            //Add email body and file attachments
            BodyBuilder bodyBuilder = new BodyBuilder();

            string tableRows = "";
            string itemRow = "";

            foreach (var item in order.CartItems)
            {
                itemRow = $"<tr><td>{item.PartNumber}</td><td>{item.Categories}</td><td>{item.Quantity}</td></tr>";
                tableRows += itemRow;
            }

            string table = $"<table><tbody>{tableRows}</table></tbody>";

            bodyBuilder.HtmlBody = $"{table}";
            bodyBuilder.TextBody = "Hello World!";

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
