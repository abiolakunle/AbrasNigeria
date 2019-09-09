using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace AbrasNigeria.Models
{
    public class StockProductHistory
    {
        public int StockProductHistoryId { get; set; }

        public int StockProductId { get; set; }

        public int AddedQuantity { get; set; }

        public int RemovedQuantity { get; set; }

        public string Note { get; set; }

        [DatabaseGenerated(DatabaseGeneratedOption.Computed)]
        public DateTime Date { get; set; }

    }
}
