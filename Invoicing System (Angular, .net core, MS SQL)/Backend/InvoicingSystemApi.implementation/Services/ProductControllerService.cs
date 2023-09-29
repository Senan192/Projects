using Microsoft.Extensions.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Text;
using System.Windows.Input;
using WebApplication1.implementation.Models;

namespace WebApplication1.implementation.Services
{
    public class ProductControllerService
    {
        private readonly SqlConnection _sqlConnection;

        public ProductControllerService(IConfiguration configuration)
        {
            string connectionString = configuration.GetConnectionString("DB");
            _sqlConnection = new SqlConnection(connectionString);
        }

        public int AddProduct(Product product)
        {
            int generatedID = 0;
            SqlCommand command = new SqlCommand("AddProduct", _sqlConnection);
            command.CommandType = CommandType.StoredProcedure;
            command.Parameters.AddWithValue("@name", product.Name);
            command.Parameters.AddWithValue("@description", product.Description);
            command.Parameters.AddWithValue("@purchaseP", product.PurchasePrice);
            command.Parameters.AddWithValue("@sellingP", product.SellingPrice);
            command.Parameters.AddWithValue("@quantity", product.Quantity);

            _sqlConnection.Open();

            object result = command.ExecuteScalar();

            if (result != null && int.TryParse(result.ToString(), out int convertedID))
            {
                generatedID = convertedID;
            }
            _sqlConnection.Close();
            return generatedID;
        }

        public Product GetProduct(int id)
        {
            _sqlConnection.Open();

            Product product = null;
            SqlCommand command = new SqlCommand("GetProductById", _sqlConnection);
            command.CommandType = CommandType.StoredProcedure;
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

                product = new Product()
                {
                    Id = productId,
                    Name = productName,
                    Description = description,
                    PurchasePrice = purchasePrice,
                    SellingPrice = sellingPrice,
                    Quantity = quantity,
                };

            }
            reader.Close();
            _sqlConnection.Close();
            return product;
        }

        public List<Product> GetProducts()
        {
            List<Product> products = new List<Product>();
            _sqlConnection.Open();

            SqlCommand command = new SqlCommand("GetProducts", _sqlConnection);
            command.CommandType = CommandType.StoredProcedure;
            SqlDataReader reader = command.ExecuteReader();

            while (reader.Read())
            {
                int productId = (int)reader["id"];
                string productName = (string)reader["name"];
                string description = (string)reader["description"];
                int purchasePrice = (int)reader["purchaseP"];
                int sellingPrice = (int)reader["sellingP"];
                int quantity = (int)reader["quantity"];

                Product product = new Product()
                {
                    Id = productId,
                    Name = productName,
                    Description = description,
                    PurchasePrice = purchasePrice,
                    SellingPrice = sellingPrice,
                    Quantity = quantity,
                };
                products.Add(product);
            }

            reader.Close();
            _sqlConnection.Close();
            return products;
        }

        public int GetPPrice(int id)
        {
            int price = 0;
            _sqlConnection.Open();

            SqlCommand command = new SqlCommand("GetPPrice", _sqlConnection);
            command.CommandType = CommandType.StoredProcedure;

            command.Parameters.AddWithValue("@id", id);
            using (SqlDataReader reader = command.ExecuteReader())
            {
                if (reader.Read())
                {
                    price = reader.GetInt32(0);
                }
            }

            _sqlConnection.Close();
            return price;
        }

        public string GetPName(int id)
        {
            string name = "";
            _sqlConnection.Open();

            SqlCommand command = new SqlCommand("GetPName", _sqlConnection);
            command.CommandType= CommandType.StoredProcedure;
            command.Parameters.AddWithValue("@id", id);
            using (SqlDataReader reader = command.ExecuteReader())
            {
                while (reader.Read())
                {
                    name = reader.GetString(0);
                }
            }


            _sqlConnection.Close();
            return name;
        }

        public bool CheckStockAvailable(int id, int quantityInvoice)
        {
            int quantity = 0;
            _sqlConnection.Open();
            SqlCommand command = new SqlCommand("CheckStockAvailable", _sqlConnection);
            command.CommandType= CommandType.StoredProcedure;
            command.Parameters.AddWithValue("@id", id);
            using (SqlDataReader reader = command.ExecuteReader())
            {
                if (reader.Read())
                {
                    quantity = reader.GetInt32(0);
                }
            }
            _sqlConnection.Close();
            return quantity >= quantityInvoice;
        }

        public int GetStock(int id)
        {
            int quantity = 0;
            _sqlConnection.Open();
            SqlCommand command = new SqlCommand("GetStock", _sqlConnection);
            command.CommandType = CommandType.StoredProcedure;
            command.Parameters.AddWithValue("@id", id);
            using (SqlDataReader reader = command.ExecuteReader())
            {
                if (reader.Read())
                {
                    quantity = reader.GetInt32(0);
                }
            }

            _sqlConnection.Close();
            return quantity;
        }

        public int UpdateQuantity(int id, int quantity)
        {
            _sqlConnection.Open();

            SqlCommand command = new SqlCommand("UpdateQuantity", _sqlConnection);
            command.CommandType = CommandType.StoredProcedure;

            command.Parameters.AddWithValue("@quantity", quantity);
            command.Parameters.AddWithValue("@id", id);
            int rowsAffected = command.ExecuteNonQuery();

            _sqlConnection.Close();
            return rowsAffected;
        }

        public int DeleteProduct(int id)
        {
            _sqlConnection.Open();
            SqlCommand command = new SqlCommand("DeleteProduct", _sqlConnection);
            command.CommandType= CommandType.StoredProcedure;
            command.Parameters.AddWithValue("@id", id);

            int rowsAffected = command.ExecuteNonQuery();
            return rowsAffected;
        }
    }
}
