using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WebApplication1.implementation.Models
{
    public class Product
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public int PurchasePrice { get; set; }
        public int SellingPrice { get; set; }
        public int Quantity { get; set; }

    }
}
