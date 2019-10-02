using AbrasNigeria.Data.DbContexts;
using AbrasNigeria.Data.DTO;
using AbrasNigeria.Data.Interfaces;
using AbrasNigeria.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AbrasNigeria.Data.Repositories
{
    public class StockProductRepository : Repository<StockProduct>, IStockProductRepository
    {

        public StockProductRepository(AppDbContext context) : base(context)
        {

        }

        public IEnumerable<StockProductDTO> LoadAllWithHistory()
        {
            IEnumerable<StockProductDTO> products = _context.StockProducts
                 .Include(s => s.StockProductHistories).Select(p => new StockProductDTO
                 {
                     StockProductId = p.StockProductId,
                     Brand = p.Brand,
                     Category = p.Category,
                     PartNumber = p.PartNumber,
                     Quantity = p.StockProductHistories
                     .Sum(ph => ph.AddedQuantity - ph.RemovedQuantity),
                     ThumbUrl = p.ThumbUrl
                 });

            return products;
        }

        public void AddHistory(StockProductHistory productHistory)
        {
            StockProduct product = _context.StockProducts
                .Where(p => p.StockProductId == productHistory.StockProductId)
                .FirstOrDefault();
            product.StockProductHistories.Add(productHistory);
            _context.Update(product);
        }

        public StockProduct LoadWithHistory(int id)
        {
            return _context.StockProducts
                .Where(p => p.StockProductId == id)
                .Include(p => p.StockProductHistories).FirstOrDefault();
        }

        //public void AddStockHistory(int productId, StockProductHistory productHistory)
        //{
        //    StockProduct product = _context
        //        .StockProducts
        //        .Where(p => p.StockProductId == productId).FirstOrDefault();

        //    product.StockProductHistories.Add(productHistory);

        //    _context.Update(product);
        //}

    }
}
