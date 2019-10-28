using AbrasNigeria.Data.DTO;
using AbrasNigeria.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AbrasNigeria.Data.Interfaces
{
    public interface IStockProductRepository : IRepository<StockProduct>
    {
        IEnumerable<StockProductDTO> LoadAllWithHistory();
        StockProduct LoadWithHistory(long id);
        void AddHistory(StockProductHistory productHistory);
    }
}
