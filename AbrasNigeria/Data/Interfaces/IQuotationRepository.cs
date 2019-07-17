using AbrasNigeria.Data.Repositories;
using AbrasNigeria.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AbrasNigeria.Data.Interfaces
{
    public interface IQuotationRepository : IRepository<Quotation>
    {
        IEnumerable<Quotation> LoadAllWithItems();
        Quotation LoadWithItems(int id);
    }
}
