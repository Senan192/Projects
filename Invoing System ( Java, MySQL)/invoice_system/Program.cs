using System.Data.SqlClient;
using System.Data;
using invoice_system.Views;
using invoice_system.Controllers;

namespace invoice_system
{
    class Program
    {
        static void Main(string[] args)
        {
           Menu menu = new Menu();
           menu.mainMenu();
           Console.ReadKey();
        }
    }
}
