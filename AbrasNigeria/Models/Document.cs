using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace AbrasNigeria.Models
{
    public class Document
    {

        public Document()
        {

        }
        public long DocumentId { get; set; }

        //[DatabaseGenerated(DatabaseGeneratedOption.Computed)]
        public string DocumentNo { get; set; }

        public string RefDocumentNo { get; set; }

        public string DocumentType { get; set; }

        public string Company { get; set; }

        public string Note { get; set; }

        [DatabaseGenerated(DatabaseGeneratedOption.Computed)]
        public DateTime? Date { get; set; }

        public ICollection<DocumentItem> Table { get; set; }

    }
}
