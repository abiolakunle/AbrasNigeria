﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

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

        public string DocType { get; set; }

        public string Company { get; set; }

        public string Note { get; set; }

        [DatabaseGenerated(DatabaseGeneratedOption.Computed)]
        public DateTime? Date { get; set; }

        public ICollection<QuotationItem> Table { get; set; }

    }
}
