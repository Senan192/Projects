using invoice_system.Controllers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace invoice_system.Views
{
    public class Menu
    {
        public void ProductMenu()
        {
            int i = -1;
            while (i != 0)
            {
                Console.WriteLine(" Enter 1 to Add Product \n 2 to Search product \n 3 to get all Products \n 4 to update \n 5 to delete");
                 i = Convert.ToInt32(Console.ReadLine());
                if (i == 1)
                {
                    ProductView.AddProduct();
                }
                else if (i == 2)
                {
                    ProductView.DisplayProduct();
                }
                else if (i == 3)
                {
                    ProductView.DisplayProducts();
                }
                else if (i == 4)
                {
                    ProductView.UpdateProduct();
                }
                else if (i == 5)
                {
                    ProductView.DeleteProduct();
                }
                else if (i == 0)
                {
                    break;
                }
            }
            
        }

        public void CustomerMenu()
        {
            int i = -1;
            while (i != 0)
            {
                Console.WriteLine(" Enter 1 to Add Customer \n 2 to Search Customer \n 3 to get all Customers \n 4 to update \n 5 to delete");
                i = Convert.ToInt32(Console.ReadLine());
                if (i == 1)
                {
                    CustomerView.AddCustomer();
                }
                else if (i == 2)
                {
                    CustomerView.GetCustomer();
                }
                else if (i == 0)
                {
                    break;
                }
            }
           
        }

        public static void InvoiceMenu()
        {
            int i = -1;
            while (i != 0)
            {
                Console.WriteLine(" Enter 1 to add Invoice \n Enter 2 to Search Invoice ");
                i = Convert.ToInt32(Console.ReadLine());
                if (i == 1)
                {
                    InvoiceView.AddDetails();
                }
                else if (i == 2)
                {
                    InvoiceView.PrintinvoiceWithID();
                }
                else if (i == 0)
                {
                    break;
                }
            }
            
        }
        public void mainMenu()
        {
            int i = -1;
            while (i != 0)
            {
                Console.WriteLine(" Enter 1 for Product Menu \n Enter 2 for Customer Menu \n Enter 3 for Invoice Menu \n Enter 4 for Admin");
                i = Convert.ToInt32(Console.ReadLine());
                if (i == 1)
                {
                    ProductMenu();
                }
                else if (i == 2)
                {
                    CustomerMenu();
                }
                else if (i == 3)
                {
                    InvoiceMenu();
                }
                else if (i == 4)
                {
                    AdminView.GetDateAndInvoices();
                }
                else if (i == 0)
                {
                    break;
                }
            }
            
        }
    }
}
