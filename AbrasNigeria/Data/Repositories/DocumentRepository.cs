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


        public DocumentRepository(AppDbContext context) : base(context)
        {

        }

        public IEnumerable<Document> LoadAllWithItems()
        {
            IEnumerable<Document> documents = _context.Documents;
            foreach (var quotation in documents)
            {
                quotation.Table = _context.DocumentItems
                    .Where(item => item.DocumentId == quotation.DocumentId).ToList();
            }

            return documents;
        }

        public Document LoadWithItems(int id)
        {
            return _context.Documents
                .Where(q => q.DocumentId == id)
                .Include(q => q.Table).FirstOrDefault();
        }

        public override void Update(Document document)
        {
            _context.Upsert(document).On(m => new { m.DocumentNo }).Run();
            Save();
        }

    }
}
