using System;
using System.Collections.Generic;
using AbrasNigeria.Data.Interfaces;
using AbrasNigeria.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

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

        // GET: api/<controller>
        [HttpGet("[action]")]
        public IEnumerable<Document> Documents()
        {
            return _documentRepository.LoadAllWithItems();
        }

        // GET api/<controller>/5
        [HttpGet("[action]")]
        public Document Document(int id)
        {
            return _documentRepository.LoadWithItems(id);
        }

        // POST api/<controller>
        [HttpPost("[action]")]
        public ActionResult CreateDocument([FromBody]Document document)
        {
            document.DocumentNo = "AN" + document.DocumentType.Substring(0, 1) + DateTime.Now.ToString("yyMMddHHmmss");
            _documentRepository.Create(document);
            return Ok();
        }

        [HttpPut("[action]")]
        public ActionResult UpdateDocument([FromBody]Document document)
        {
            _documentRepository.Update(document);
            return Ok();
        }


    }
}
