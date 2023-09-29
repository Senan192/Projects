using System.Data.SqlClient;
using invoice_system.Models;

namespace invoice_system.Controllers
{
    internal class ProductController
    {
        public static int AddProduct(Product model)
        {
            SqlConnection con = DBConnector.GetConnection();
            con.Open();

            string query = "INSERT INTO product ( name,description,purchaseP,sellingP,quantity) " +
                "VALUES (@name,@description,@purchaseP,@sellingP,@quantity);SELECT SCOPE_IDENTITY();";
            SqlCommand command = new SqlCommand(query, con);
            command.Parameters.AddWithValue("@name", model.GetpName());
            command.Parameters.AddWithValue("@description", model.GetDescription());
            command.Parameters.AddWithValue("@purchaseP", model.GetPurchaseP());
            command.Parameters.AddWithValue("@sellingP", model.GetSellingP());
            command.Parameters.AddWithValue("@quantity", model.GetQuantity());

            int generatedID = Convert.ToInt32(command.ExecuteScalar());
            return generatedID;
        }

        public static int UpdateQuantity(int id, int quantity)
        {
            using (SqlConnection con = DBConnector.GetConnection())
            {
                con.Open();

                using (SqlCommand command = new SqlCommand("UPDATE product SET quantity = @quantity WHERE id = @id", con))
                {
                    command.Parameters.AddWithValue("@quantity", quantity);
                    command.Parameters.AddWithValue("@id", id);
                    int rowsAffected = command.ExecuteNonQuery();
                    return rowsAffected;
                }
            }
        }


        public static string GetPName(int id)
        {
            string name = "";
            using (SqlConnection con = DBConnector.GetConnection())
            {
                con.Open();

                using (SqlCommand command = new SqlCommand("SELECT name FROM product WHERE id = @id", con))
                {
                    command.Parameters.AddWithValue("@id", id);
                    using (SqlDataReader reader = command.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            name = reader.GetString(0);
                        }
                    }
                }
            }

            return name;
        }

        public static bool CheckStockAvailable(int id, int quantityInvoice)
        {
            int quantity = 0;
            using (SqlConnection con = DBConnector.GetConnection())
            {
                con.Open();

                using (SqlCommand command = new SqlCommand("SELECT quantity FROM product WHERE id = @id", con))
                {
                    command.Parameters.AddWithValue("@id", id);
                    using (SqlDataReader reader = command.ExecuteReader())
                    {
                        if (reader.Read())
                        {
                            quantity = reader.GetInt32(0);
                        }
                    }
                }
            }

            return quantity >= quantityInvoice;
        }

        public static int GetPPrice(int id)
        {
            int price = 0;
            using (SqlConnection con = DBConnector.GetConnection())
            {
                con.Open();

                using (SqlCommand command = new SqlCommand("SELECT sellingP FROM product WHERE id = @id", con))
                {
                    command.Parameters.AddWithValue("@id", id);
                    using (SqlDataReader reader = command.ExecuteReader())
                    {
                        if (reader.Read())
                        {
                            price = reader.GetInt32(0);
                        }
                    }
                }
            }

            return price;
        }

        public static int GetStock(int id)
        {
            int quantity = 0;
            using (SqlConnection con = DBConnector.GetConnection())
            {
                con.Open();

                using (SqlCommand command = new SqlCommand("SELECT quantity FROM product WHERE id = @id", con))
                {
                    command.Parameters.AddWithValue("@id", id);
                    using (SqlDataReader reader = command.ExecuteReader())
                    {
                        if (reader.Read())
                        {
                            quantity = reader.GetInt32(0);
                        }
                    }
                }
            }

            return quantity;
        }


        public static Product GetProduct(int id)
        {
            Product model = null;
            SqlConnection con = DBConnector.GetConnection();
            con.Open();
            string query = "SELECT * FROM product where id=@id";
            SqlCommand command = new SqlCommand(query, con);
            command.Parameters.AddWithValue("@id", id);
            SqlDataReader reader = command.ExecuteReader();

            if (reader.Read())
            {
                int productId = (int)reader["id"];
                string productName = (string)reader["name"];
                string description = (string)reader["description"];
                int purchasePrice = (int)reader["purchaseP"];
                int sellingPrice = (int)reader["sellingP"];
                int quantity = (int)reader["quantity"];

                model = new Product(productId, productName, description, purchasePrice, sellingPrice, quantity);

            }
            reader.Close();
            con.Close();
            return model;
        }

        public static List<Product> GetProducts()
        {
            List<Product> products = new List<Product>();

            SqlConnection con = DBConnector.GetConnection();
            con.Open();
            string query = "SELECT * FROM product";
            SqlCommand command = new SqlCommand(query, con);
            SqlDataReader reader = command.ExecuteReader();

            while (reader.Read())
            {
                int productId = (int)reader["id"];
                string productName = (string)reader["name"];
                string description = (string)reader["description"];
                int purchasePrice = (int)reader["purchaseP"];
                int sellingPrice = (int)reader["sellingP"];
                int quantity = (int)reader["quantity"];

                Product product = new Product(productId, productName, description, purchasePrice, sellingPrice, quantity);
                products.Add(product);
            }

            reader.Close();
            con.Close();
            return products;
        }

        public static int UpdateProduct(int id, Product model)
        {
            SqlConnection con = DBConnector.GetConnection();
            con.Open();

            string query = "UPDATE product SET name = @name, description = @description, purchaseP = @purchaseP, sellingP = @sellingP, quantity = @quantity WHERE id = @id";
            SqlCommand command = new SqlCommand(query, con);
            command.Parameters.AddWithValue("@id", id);
            command.Parameters.AddWithValue("@name", model.GetpName());
            command.Parameters.AddWithValue("@description", model.GetDescription());
            command.Parameters.AddWithValue("@purchaseP", model.GetPurchaseP());
            command.Parameters.AddWithValue("@sellingP", model.GetSellingP());
            command.Parameters.AddWithValue("@quantity", model.GetQuantity());

            int rowsAffected = command.ExecuteNonQuery();
            return rowsAffected;
        }

        public static int DeleteProduct(int id)
        {
            SqlConnection con = DBConnector.GetConnection();
            con.Open();

            string query = "DELETE FROM product WHERE id= @id";
            SqlCommand command = new SqlCommand(query, con);
            command.Parameters.AddWithValue("@id", id);

            int rowsAffected = command.ExecuteNonQuery();
            return rowsAffected;
        }
    }
}
