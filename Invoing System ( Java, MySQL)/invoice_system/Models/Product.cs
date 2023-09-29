using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace invoice_system.Models
{
    public class Product
    {
        private int pID { get; set; }
        private string pMame { get; set; }
        private string pDescription { get; set; }
        private int pPurchasePrice { get; set; }
        private int pSellingPrice { get; set; }
        private int pQuantity { get; set; }

        public int GetpID() { return pID; }
        public string GetpName() { return pMame; }
        public string GetDescription() { return pDescription; }
        public int GetPurchaseP() { return pPurchasePrice; }
        public int GetSellingP() { return pSellingPrice; }
        public int GetQuantity() { return pQuantity; }

        public Product(int pID, string pName, string pDescription, int pPurchasePrice, int pSellingPrice, int pQuantity)
        {
            this.pID = pID;
            pMame = pName;
            this.pDescription = pDescription;
            this.pPurchasePrice = pPurchasePrice;
            this.pSellingPrice = pSellingPrice;
            this.pQuantity = pQuantity;
        }

        public Product(string pName, string pDescription, int pPurchasePrice, int pSellingPrice, int pQuantity)
        {
            pMame = pName;
            this.pDescription = pDescription;
            this.pPurchasePrice = pPurchasePrice;
            this.pSellingPrice = pSellingPrice;
            this.pQuantity = pQuantity;
        }
    }
}
