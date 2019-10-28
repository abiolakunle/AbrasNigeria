using System;
using System.ComponentModel.DataAnnotations.Schema;

namespace AbrasNigeria.Models
{
    public class StockProductHistory
    {
        public long StockProductHistoryId { get; set; }

        public long StockProductId { get; set; }

        public int AddedQuantity { get; set; }

        public int RemovedQuantity { get; set; }

        public string Note { get; set; }

        [DatabaseGenerated(DatabaseGeneratedOption.Computed)]
        public DateTime Date { get; set; }

    }
}
