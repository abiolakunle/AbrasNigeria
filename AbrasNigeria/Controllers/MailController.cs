using AbrasNigeria.Models;
using Microsoft.AspNetCore.Mvc;
using IronPdf;
using System.IO;
using Microsoft.AspNetCore.Hosting;

namespace AbrasNigeria.Controllers
{
    [Route("api/[controller]")]
    public class MailController : Controller
    {
        private readonly IHostingEnvironment _hostingEnvironment;

        public MailController(IHostingEnvironment hostingEnvironment)
        {
            _hostingEnvironment = hostingEnvironment;
        }
        [HttpPost("[action]")]
        public IActionResult Send([FromBody] Mail mail)
        {
            var filePath = Path.Combine(Directory.GetCurrentDirectory(), _hostingEnvironment.WebRootPath, "uploads/" + mail.AttachmentId);

            // Create a PDF from any existing web page
            var Renderer = new IronPdf.HtmlToPdf();
            var PDF = Renderer.RenderUrlAsPdf($"https://localhost:44343/view/{mail.AttachmentId}");
            PDF.SaveAs(filePath);
            // This neat trick opens our PDF file so we can see the result
            System.Diagnostics.Process.Start($"{filePath}.pdf");

            return Ok();
        }


    }
}
