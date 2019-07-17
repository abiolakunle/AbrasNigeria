using AbrasNigeria.Data.DbContexts;
using AbrasNigeria.Data.Interfaces;
using AbrasNigeria.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;

namespace AbrasNigeria.Data.Repositories
{
    public class QuotationRepository : Repository<Quotation>, IQuotationRepository
    {
        private readonly AppDbContext _dbContext;

        public QuotationRepository(AppDbContext dbContext) : base(dbContext)
        {
            _dbContext = dbContext;
        }

        public IEnumerable<Quotation> LoadAllWithItems()
        {
            IEnumerable<Quotation> quotations = _dbContext.Quotations;
            foreach (var quotation in quotations)
            {
                quotation.Table = _dbContext.QuotationItems
                    .Where(item => item.QuotationId == quotation.QuotationId).ToList();
            }

            return quotations;
        }

        public Quotation LoadWithItems(int id)
        {
            return _dbContext.Quotations
                .Where(q => q.QuotationId == id)
                .Include(q => q.Table).FirstOrDefault();
        }

    }
}
