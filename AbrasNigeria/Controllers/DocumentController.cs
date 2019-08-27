﻿using System;
using System.Collections.Generic;
using AbrasNigeria.Data.Interfaces;
using AbrasNigeria.Models;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace AbrasNigeria.Controllers
{
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
        public ActionResult<Document> CreateDocument([FromBody]Document document)
        {
            document.DocumentNo = "ANE" + DateTime.Now.ToString("yyMMddHHmmss");
            _documentRepository.Create(document);
            return Ok();
        }



    }
}