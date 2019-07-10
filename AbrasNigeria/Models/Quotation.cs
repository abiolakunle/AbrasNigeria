using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace AbrasNigeria.Models
{
    public class Quotation
    {
        public Quotation()
        {
            Date = DateTime.Now;
        }
        public int QuotationId { get; set; }

        //[DatabaseGenerated(DatabaseGeneratedOption.Computed)]
        public string QuoteNo { get; set; }

        public string Company { get; set; }

        [DatabaseGenerated(DatabaseGeneratedOption.Computed)]
        public DateTime? Date { get; set; }

        public virtual List<QuotationItem> Table { get; set; }

    }
}
