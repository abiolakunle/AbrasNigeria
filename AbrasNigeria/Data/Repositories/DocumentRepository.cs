using AbrasNigeria.Data.DbContexts;
using AbrasNigeria.Data.Interfaces;
using AbrasNigeria.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;

namespace AbrasNigeria.Data.Repositories
{
    public class DocumentRepository : Repository<Document>, IDocumentRepository
    {
        private readonly AppDbContext _dbContext;

        public DocumentRepository(AppDbContext dbContext) : base(dbContext)
        {
            _dbContext = dbContext;
        }

        public IEnumerable<Document> LoadAllWithItems()
        {
            IEnumerable<Document> documents = _dbContext.Documents;
            foreach (var quotation in documents)
            {
                quotation.Table = _dbContext.DocumentItems
                    .Where(item => item.DocumentId == quotation.DocumentId).ToList();
            }

            return documents;
        }

        public Document LoadWithItems(int id)
        {
            return _dbContext.Documents
                .Where(q => q.DocumentId == id)
                .Include(q => q.Table).FirstOrDefault();
        }

    }
}
