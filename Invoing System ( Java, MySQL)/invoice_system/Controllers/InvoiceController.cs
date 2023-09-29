using invoice_system.Models;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace invoice_system.Controllers
{
    public class InvoiceController
    {
        public static String CheckCName(int id)
        {
            String name = CustomerController.GetCName(id);
            return name;
        }
        public static int GenerateInvoice(string invoiceDate, int customerID)
        {
            string insertInvoiceQuery = "INSERT INTO Invoice (customerID, invoiceDate) VALUES (@customerID, @invoiceDate); SELECT SCOPE_IDENTITY();";

            using (SqlConnection con = DBConnector.GetConnection())
            {
                con.Open();

                using (SqlCommand command = new SqlCommand(insertInvoiceQuery, con))
                {
                    command.Parameters.AddWithValue("@customerID", customerID);
                    command.Parameters.AddWithValue("@invoiceDate", invoiceDate);
                    
                    int generatedInvoiceID = Convert.ToInt32(command.ExecuteScalar());
                    return generatedInvoiceID;
                }
            }
        }

        public static void UpdatePQuantity(int id, int stockUsed)
        {
            int previousStock = ProductController.GetStock(id);
            int newStock = previousStock - stockUsed;
            ProductController.UpdateQuantity(id, newStock);
        }


        public static void AddInvoiceItem(int invoiceID, InvoiceItems model)
        {
            int pID = model.GetProductID();
            int unitP = ProductController.GetPPrice(pID);
            int quantity = model.GetUnitsPerProduct();
            int totalP = unitP * quantity;
            InvoiceItems dbModel = new InvoiceItems(pID, quantity, unitP, totalP);

            using (SqlConnection con = DBConnector.GetConnection())
            {
                con.Open();

                using (SqlCommand command = new SqlCommand("INSERT INTO invoiceitem (invoiceID, productID, quantity, unitP, totalP) VALUES (@invoiceID, @pID, @quantity, @unitP, @totalP)", con))
                {
                    command.Parameters.AddWithValue("@invoiceID", invoiceID);
                    command.Parameters.AddWithValue("@pID", dbModel.GetProductID());
                    command.Parameters.AddWithValue("@quantity", dbModel.GetUnitsPerProduct());
                    command.Parameters.AddWithValue("@unitP", dbModel.GetUnitPrice());
                    command.Parameters.AddWithValue("@totalP", dbModel.GetTotalPrice());
                    command.ExecuteNonQuery();
                }
            }

            UpdatePQuantity(pID, quantity);
        }

        

        public static Invoice GetInvoice(int invoiceID)
        {
            using (SqlConnection con = DBConnector.GetConnection())
            {
                con.Open();

                string selectInvoiceQuery = "SELECT i.invoiceDate, c.name, ii.productID, ii.quantity, ii.unitP, ii.totalP " +
                "FROM invoice i " +
                "JOIN customer c ON i.customerID = c.id " +
                "JOIN invoiceitem ii ON i.invoiceID = ii.invoiceID " +
                "WHERE i.invoiceID = @invoiceID";

                using (SqlCommand command = new SqlCommand(selectInvoiceQuery, con))
                {
                    command.Parameters.AddWithValue("@invoiceID", invoiceID);

                    using (SqlDataReader reader = command.ExecuteReader())
                    {
                        if (reader.Read())
                        {
                            DateTime dateTimeValue = reader.GetDateTime(reader.GetOrdinal("invoiceDate"));
                            DateOnly invoiceDate = DateOnly.FromDateTime(dateTimeValue);

                            string customerName = reader.GetString("name");

                            List<InvoiceItems> items = new List<InvoiceItems>();

                            do
                            {
                                int productID = reader.GetInt32("productID");
                                int unitsPerProduct = reader.GetInt32("quantity");
                                int unitPrice = reader.GetInt32("unitP");
                                int totalPrice = reader.GetInt32("totalP");

                                InvoiceItems item = new InvoiceItems(productID, unitsPerProduct, unitPrice, totalPrice);
                                items.Add(item);
                            } while (reader.Read());

                            return new Invoice()
                            {
                                InvoiceID = invoiceID,
                                InvoiceDate = invoiceDate,
                                CustomerName = customerName,
                                Items = items
                            };
                        }
                        else
                        {
                            throw new Exception("Invoice not found.");
                        }
                    }
                }
            }
        }


    }
}
