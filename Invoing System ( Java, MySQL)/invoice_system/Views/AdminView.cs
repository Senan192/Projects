using invoice_system.Controllers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace invoice_system.Views
{
    public class AdminView
    {
        public static void GetDateAndInvoices()
        {
            Console.WriteLine("Enter date");
            string dateString = Console.ReadLine();
            string formattedDate = "";
            if (DateTime.TryParse(dateString, out DateTime date))
            {
                formattedDate = date.ToString("yyyy-MM-dd");
                List<int> invioceIds=AdminController.GetInvoiceIDsForDate(formattedDate);
                foreach (int invioceId in invioceIds) 
                {
                    InvoiceView.PrintInvoice(invioceId);
                }
            }
            else
            {
                Console.WriteLine("Invalid date format. Please enter a valid date in the format yyyy-MM-dd.");
            }
        }

    }
}
