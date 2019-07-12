using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AbrasNigeria.Models
{
    public class Mail
    {
        public string Address { get; set; }

        public string Subject { get; set; }

        public string Message { get; set; }

        public int AttachmentId { get; set; }
    }
}
