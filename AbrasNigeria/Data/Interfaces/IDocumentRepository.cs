using AbrasNigeria.Data.DTO;
using AbrasNigeria.Data.Repositories;
using AbrasNigeria.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AbrasNigeria.Data.Interfaces
{
    public interface IDocumentRepository : IRepository<Document>
    {
        IEnumerable<Document> LoadAllWithItems();
        DocumentDTO LoadWithItems(int id);
    }
}
