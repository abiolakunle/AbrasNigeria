using AbrasNigeria.Data.DbContexts;
using AbrasNigeria.Data.Services;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.IO;
using System.Threading.Tasks;


namespace AbrasNigeria.Controllers
{
    [Route("api/[controller]")]
    public class ExcelToDbController : Controller
    {
        private readonly IHostingEnvironment _environment;
        private readonly AppDbContext _dbContext;
        private ExcelPartBookToDb _bookToDb;

        public ExcelToDbController(IHostingEnvironment environment, AppDbContext dbContext, ExcelPartBookToDb bookToDb)
        {
            _environment = environment;
            _dbContext = dbContext;
            _bookToDb = bookToDb;
        }

        [HttpPost("[action]")]
        public async Task<IActionResult> UploadExcel(IFormFile masterFile)
        {
            if (masterFile == null || masterFile.Length == 0)
            {
                return Content("File not selected");
            }

            //get the file extension
            string fileExtension = Path.GetExtension(masterFile.FileName);

            //Validate uploaded file and return error
            if (fileExtension != ".xls" && fileExtension != ".xlsx")
            {
                //ViewBag.Message = "Please select the excel file with .xls or .xlsx extension";
                //return View();
            }

            await _bookToDb.CopyToDbNew(masterFile);

            return Ok();

        }
    }

    public class FileLogger
    {
        public static void Log(string logInfo, IHostingEnvironment environment, string fileName)
        {
            var filePath = Path.Combine(Directory.GetCurrentDirectory(), environment.WebRootPath, "uploads/" + fileName + "log");
            File.AppendAllText(filePath, logInfo);
        }
    }
}
