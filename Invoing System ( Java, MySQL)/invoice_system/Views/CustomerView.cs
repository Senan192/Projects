using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using invoice_system.Controllers;
using invoice_system.Models;

namespace invoice_system.Views
{
    public class CustomerView
    {
        public static void AddCustomer()
        {
            Console.WriteLine("Enter Name");
            string name = Console.ReadLine();
            Console.WriteLine("Enter Email");
            string email = Console.ReadLine();
            Console.WriteLine("Enter address");
            string address = Console.ReadLine();
            Console.WriteLine("Enter Contact");
            int contact = Convert.ToInt32(Console.ReadLine());
            Console.WriteLine("Enter dob");
            string dob = Console.ReadLine();
            Console.WriteLine("Enter gender");
            string gender = Console.ReadLine();

            Customer model = new Customer(name, email, address, contact, dob, gender);
            int customerId = CustomerController.AddCustomer(model);
            Console.WriteLine("Customer ID: " + customerId);
        }

        public static void GetCustomer()
        {
            Console.WriteLine("Enter customer ID");
            int id = Convert.ToInt32(Console.ReadLine());
            Customer customer = CustomerController.GetCustomer(id);
            Console.WriteLine(
                "Name = " + customer.GetName() +
                "\nEmail = " + customer.GetEmail() +
                "\nAddress = " + customer.GetAddress() +
                "\nContact = " + customer.GetContact()+
                "\nDOB = "+ customer.GetDate()+
                "\nGender = " +customer.GetGender());
        }

        public static void DeleteCustomer()
        {
            Console.WriteLine("Enter ID");
            int id = Convert.ToInt32(Console.ReadLine());
            int rowsAffected = CustomerController.DeleteCustomer(id);
            Console.WriteLine("RowsAffected= " + rowsAffected);
        } 

    }
}
