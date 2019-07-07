using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AbrasNigeria.Models
{
    public class Quotation
    {
        public int QuotationId { get; set; }

        public string QuoteNo { get; set; }

        public string Company { get; set; }

        public DateTime Date { get; set; }

        public virtual List<QuotationItem> Table { get; set; }

    }
}
