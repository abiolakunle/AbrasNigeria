using System;
using System.Collections.Generic;
using AbrasNigeria.Data.Interfaces;
using AbrasNigeria.Models;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace AbrasNigeria.Controllers
{
    [Route("api/[controller]")]
    public class QuotationController : Controller
    {
        private readonly IQuotationRepository _quotationRepository;

        public QuotationController(IQuotationRepository quotationRepository)
        {
            _quotationRepository = quotationRepository;
        }

        // GET: api/<controller>
        [HttpGet]
        public IEnumerable<Quotation> Get()
        {
            return _quotationRepository.GetAll();
        }

        // GET api/<controller>/5
        [HttpGet("{id}")]
        public Quotation Get(int id)
        {
            return _quotationRepository.GetById(id);
        }

        // POST api/<controller>
        [HttpPost]
        public ActionResult<Quotation> Post([FromBody]Quotation value)
        {
            _quotationRepository.Create(value);
            return Ok();
        }

        // PUT api/<controller>/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody]string value)
        {
        }

        // DELETE api/<controller>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
