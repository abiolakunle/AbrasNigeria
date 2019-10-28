using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AbrasNigeria.Data.DTO
{
    public class DocumentDTO
    {
        public DocumentDTO()
        {
            Date = DateTime.Now;
        }
        public long DocumentId { get; set; }

        public string DocumentNo { get; set; }

        public string RefDocumentNo { get; set; }

        public string DocumentType { get; set; }

        public string Company { get; set; }

        public string Note { get; set; }

        public DateTime? Date { get; set; }

        public ICollection<DocumentItemDTO> Table { get; set; }
    }
}
