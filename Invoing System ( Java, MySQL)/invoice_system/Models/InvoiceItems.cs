using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace invoice_system.Models
{
    public class InvoiceItems
    {
        public int ProductID { get; set; }
        public string ProductName { get; set; }
        public int UnitsPerProduct { get; set; }
        public double UnitPrice { get; set; }
        public double TotalPrice { get; set; }

        public InvoiceItems(int productID, int unitsPerProduct, double unitPrice, double totalPrice)
        {
            ProductID = productID;
            UnitsPerProduct = unitsPerProduct;
            UnitPrice = unitPrice;
            TotalPrice = totalPrice;
        }

        public InvoiceItems(int productID, int unitsPerProduct)
        {
            ProductID = productID;
            UnitsPerProduct = unitsPerProduct;
        }

        public int GetProductID() { return ProductID; }
        public int GetUnitsPerProduct() { return UnitsPerProduct; }
        public double GetUnitPrice() { return UnitPrice; }
        public double GetTotalPrice() { return TotalPrice; }
    }
}
