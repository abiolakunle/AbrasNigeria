using AbrasNigeria.Data.DbContexts;
using AbrasNigeria.Data.DTO;
using AbrasNigeria.Data.Interfaces;
using AbrasNigeria.Models;
using AutoMapper;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;

namespace AbrasNigeria.Data.Repositories
{
    public class DocumentRepository : Repository<Document>, IDocumentRepository
    {
        private readonly IMapper _mapper;

        public DocumentRepository(AppDbContext context, IMapper mapper) : base(context)
        {
            _mapper = mapper;
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

        public DocumentDTO LoadWithItems(int id)
        {
            var document = _context.Documents
                 .Where(q => q.DocumentId == id)
                 .Include(q => q.Table).FirstOrDefault();

            DocumentDTO documentDTO = _mapper.Map<DocumentDTO>(document);

            return documentDTO;
        }

        public override void Update(Document document)
        {
            _context.Upsert(document).On(m => new { m.DocumentNo }).Run();
            Save();
        }

    }
}
