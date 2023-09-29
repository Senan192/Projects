
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WebApplication1.implementation.Models
{
    public class Invoice
    {
        public int InvoiceID { get; set; }
        public DateOnly InvoiceDate { get; set; }
        public string CustomerName { get; set; }
        public List<InvoiceItems> Items { get; set; }
    }
}
