using invoice_system.Controllers;
using invoice_system.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace invoice_system.Views
{
    public class InvoiceView
    {
        public static int GetCId()
        {
            Console.WriteLine("Enter Customer ID");
            int cID = Convert.ToInt32(Console.ReadLine());
            string name = InvoiceController.CheckCName(cID);
            if (string.IsNullOrEmpty(name))
            {
                Console.WriteLine("Incorrect Customer ID");
                Menu.InvoiceMenu();
                return 0;
            }
            else
            {
                return cID;
            }
        }

        public static int GetPId()
        {
            Console.WriteLine("Enter Product ID \n Enter 0 to Stop adding Products");
            int pID = Convert.ToInt32(Console.ReadLine());
            string name = ProductController.GetPName(pID);
            if (string.IsNullOrEmpty(name) && pID != 0)
            {
                Console.WriteLine("Incorrect Product ID");
                pID = 0;
            }
            return pID;
        }

        public static int GetProductDetails(int pID)
        {
            string name = ProductController.GetPName(pID);
            Console.WriteLine("Enter number of units of " + name);
            int quantity = Convert.ToInt32(Console.ReadLine());
            return quantity;
        }


        public static void AddDetails()
        {
            Console.WriteLine("Enter date");
            string dateString = Console.ReadLine();
            string formattedDate = "";
            if (DateTime.TryParse(dateString, out DateTime date))
            {
                 formattedDate = date.ToString("yyyy-MM-dd");
                int cId = 0;
                cId = GetCId();
                int iID = InvoiceController.GenerateInvoice(formattedDate, cId);
                int pID = -1;
                while (pID != 0)
                {
                    pID = GetPId();
                    if (pID == 0)
                    {
                        PrintInvoice(iID);
                        break;
                    }
                    Console.WriteLine("PID=" + pID);
                    int quantity = GetProductDetails(pID);
                    bool stockAvailable = ProductController.CheckStockAvailable(pID, quantity);
                    if (stockAvailable)
                    {
                        InvoiceItems iiModel = new InvoiceItems(pID, quantity);
                        InvoiceController.AddInvoiceItem(iID, iiModel);
                        Console.WriteLine("Added item");
                    }
                    else
                    {
                        Console.WriteLine("Insufficient Stocks");
                    }

                }
            }
            else
            {
                Console.WriteLine("Invalid date format. Please enter a valid date in the format yyyy-MM-dd.");
            }
           
           
        }

        public static void PrintinvoiceWithID()
        {
            Console.WriteLine("Enter invoice ID:");
            int iID = Convert.ToInt32(Console.ReadLine());
            PrintInvoice(iID);
        }
        public static Invoice PrintInvoice(int iID)
        {
            Invoice invoice = InvoiceController.GetInvoice(iID);
            Console.WriteLine("Invoice Number: " + invoice.InvoiceID);
            Console.WriteLine("Invoice Date: " + invoice.InvoiceDate);
            Console.WriteLine("Customer Name: " + invoice.CustomerName);
            Console.WriteLine("------------------------------");
            Console.WriteLine("Product\tName\tUnits\tPrice\tTotal");
            Console.WriteLine("------------------------------");

            List<InvoiceItems> items = invoice.Items;
            foreach (InvoiceItems item in items)
            {
                Console.WriteLine(item.GetProductID() + "\t" + ProductController.GetPName(item.ProductID) + item.GetUnitsPerProduct() + "\t" + item.GetUnitPrice() + "\t" + item.GetTotalPrice());
            }

            Console.WriteLine("------------------------------");
            return invoice;
        }


    }
}
