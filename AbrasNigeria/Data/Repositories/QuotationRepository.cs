using AbrasNigeria.Data.DbContexts;
using AbrasNigeria.Data.Interfaces;
using AbrasNigeria.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;

namespace AbrasNigeria.Data.Repositories
{
    public class QuotationRepository : IQuotationRepository
    {
        private readonly QuoteDbContext _quoteDbContext;

        public QuotationRepository(QuoteDbContext quoteDbContext)
        {
            _quoteDbContext = quoteDbContext;
        }

        public int Count(Func<Quotation, bool> predicate)
        {
            throw new NotImplementedException();
        }

        public void Create(Quotation quotation)
        {
            _quoteDbContext.Quotations.Add(quotation);
            _quoteDbContext.SaveChanges();
        }

        public void Delete(Quotation entity)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Quotation> Find(Func<Quotation, bool> predicate)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Quotation> GetAll()
        {
            IEnumerable<Quotation> quotations = _quoteDbContext.Quotations;
            foreach (var quotation in quotations)
            {
                quotation.Table = _quoteDbContext.QuotationItems
                    .Where(item => item.QuotationId == quotation.QuotationId).ToList();
            }

            return quotations;
        }

        public Quotation GetById(int id)
        {
            return _quoteDbContext.Quotations
                .Where(q => q.QuotationId == id)
                .Include(q => q.Table).FirstOrDefault();
        }

        public Quotation GetQuotation(int quotationId)
        {
            Quotation quotation = _quoteDbContext.Quotations
                .Where(quot => quot.QuotationId == quotationId)
                .Include(q => q.Table).FirstOrDefault();
            return quotation;
        }

        public void Update(Quotation entity)
        {
            throw new NotImplementedException();
        }
    }
}
