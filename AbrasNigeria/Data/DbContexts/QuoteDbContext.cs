using AbrasNigeria.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AbrasNigeria.Data.DbContexts
{
    public class QuoteDbContext : DbContext
    {
        public QuoteDbContext(DbContextOptions options) : base(options)
        {

        }

        public DbSet<QuotationItem> QuotationItems { get; set; }

        public DbSet<Quotation> Quotations { get; set; }

    }
}
