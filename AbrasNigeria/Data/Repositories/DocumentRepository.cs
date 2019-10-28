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
            IEnumerable<Document> documents = _table.Include(d => d.Table);

            return documents;
        }

        public DocumentDTO LoadWithItems(int id)
        {
            var document = _table
                 .Where(q => q.DocumentId == id)
                 .Include(q => q.Table).FirstOrDefault();

            DocumentDTO documentDTO = _mapper.Map<DocumentDTO>(document);

            return documentDTO;
        }

        public override void Update(Document document)
        {
            _table.Upsert(document).On(m => new { m.DocumentNo }).Run();
            Save();
        }

    }
}
