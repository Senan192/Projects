using invoice_system.Controllers;
using invoice_system.Models;

namespace invoice_system.Views
{
    public class ProductView
    {
        public static void AddProduct()
        {
            Console.WriteLine("Enter Name");
            string name = Console.ReadLine();
            Console.WriteLine("Enter Description");
            string description = Console.ReadLine();
            Console.WriteLine("Enter Purchase Price");
            int purchaseP = Convert.ToInt32(Console.ReadLine());
            Console.WriteLine("Enter Selling Price");
            int sellingP = Convert.ToInt32(Console.ReadLine());
            Console.WriteLine("Enter Quantity");
            int quantity = Convert.ToInt32(Console.ReadLine());

            Product model = new Product(name, description, purchaseP, sellingP, quantity);
            int ProductId = ProductController.AddProduct(model);
            Console.WriteLine("Product ID: " + ProductId);
        }


        public static void DisplayProduct()
        {
            Console.WriteLine("enter id");
            int id = Convert.ToInt32(Console.ReadLine());
            Product model = ProductController.GetProduct(id);
            Console.WriteLine(
                "ID = " + model.GetpID()+
                "\nName = "+model.GetpName()+
                "\nDescription = "+ model.GetDescription()+
                "\nPurchase price = "+model.GetPurchaseP()+
                "\nSelling Price = "+ model.GetSellingP()+
                "\nQuantity = " + model.GetQuantity());
        }

        public static void DisplayProducts()
        {
            List<Product> products = ProductController.GetProducts();
            foreach (Product product in products)
            {
                Console.WriteLine($"ID: {product.GetpID()}");
                Console.WriteLine($"Name: {product.GetpName()}");
                Console.WriteLine($"Description: {product.GetDescription()}");
                Console.WriteLine($"Purchase Price: {product.GetPurchaseP()}");
                Console.WriteLine($"Selling Price: {product.GetSellingP()}");
                Console.WriteLine($"Quantity: {product.GetQuantity()}");
                Console.WriteLine("--------------------------");
            }
        }

        public static void UpdateProduct()
        {
            Console.WriteLine("Enter Product ID to change ");
            int id = Convert.ToInt32(Console.ReadLine());
            Console.WriteLine("Enter new Name");
            string name = Console.ReadLine();
            Console.WriteLine("Enter new Description");
            string description = Console.ReadLine();
            Console.WriteLine("Enter new Purchase Price");
            int purchaseP = Convert.ToInt32(Console.ReadLine());
            Console.WriteLine("Enter new Selling Price");
            int sellingP = Convert.ToInt32(Console.ReadLine());
            Console.WriteLine("Enter new Quantity");
            int quantity = Convert.ToInt32(Console.ReadLine());

            Product model = new Product(name, description, purchaseP, sellingP, quantity);
            int rowsAffected = ProductController.UpdateProduct(id, model);
            Console.WriteLine("Record Entered: " + rowsAffected);
        }

        public static void DeleteProduct()
        {
            Console.WriteLine("Enter Product ID to change ");
            int id = Convert.ToInt32(Console.ReadLine());
            int rowsAffected = ProductController.DeleteProduct(id);
            Console.WriteLine("Record Entered: " + rowsAffected);
        }
    }

}
