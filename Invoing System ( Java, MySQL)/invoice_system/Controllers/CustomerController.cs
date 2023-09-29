using System.Data.SqlClient;
using invoice_system.Models;

namespace invoice_system.Controllers
{
    public class CustomerController
    {
        public static int AddCustomer(Customer model)
        {
            SqlConnection con = DBConnector.GetConnection();
            con.Open();

            string query = "INSERT INTO customer (name,email,address,contact,dob,gender) " +
                "VALUES (@name,@email,@address,@contact,@dob,@gender);SELECT SCOPE_IDENTITY();";
            SqlCommand command = new SqlCommand(query, con);

            command.Parameters.AddWithValue("@name", model.GetName());
            command.Parameters.AddWithValue("@email", model.GetEmail());
            command.Parameters.AddWithValue("@address", model.GetAddress());
            command.Parameters.AddWithValue("@contact", model.GetContact());
            command.Parameters.AddWithValue("@dob", model.GetDate());
            command.Parameters.AddWithValue("@gender", model.GetGender());

            int generatedInvoiceID = Convert.ToInt32(command.ExecuteScalar());
            return generatedInvoiceID;
        }

        public static string GetCName(int id)
        {
            string name = "";
            using (SqlConnection con = DBConnector.GetConnection())
            {
                con.Open();

                using (SqlCommand command = new SqlCommand("SELECT name FROM customer WHERE id = @id", con))
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

        public static Customer GetCustomer(int id)
        {
            Customer model = null;
            SqlConnection con = DBConnector.GetConnection();
            con.Open();
            string query = "SELECT * FROM customer where id=@id";
            SqlCommand command = new SqlCommand(query, con);
            command.Parameters.AddWithValue("@id", id);
            SqlDataReader reader = command.ExecuteReader();

            if (reader.Read())
            {
                int productId = (int)reader["id"];
                string productName = (string)reader["name"];
                string email = (string)reader["email"];
                string address = (string)reader["address"];
                int contact = (int)reader["contact"];
                string dob = (string)reader["dob"];
                string gender = (string)reader["gender"];

                model = new Customer(productId, productName, email, address, contact, dob, gender);

            }
            reader.Close();
            con.Close();
            return model;
        }

        public static List<Customer> GetCustomers()
        {
            List<Customer> customers = new List<Customer>();

            SqlConnection con = DBConnector.GetConnection();
            con.Open();
            string query = "SELECT * FROM customer";
            SqlCommand command = new SqlCommand(query, con);
            SqlDataReader reader = command.ExecuteReader();

            while (reader.Read())
            {
                int productId = (int)reader["id"];
                string productName = (string)reader["name"];
                string email = (string)reader["email"];
                string address = (string)reader["address"];
                int contact = (int)reader["contact"];
                string dob = (string)reader["dob"];
                string gender = (string)reader["gender"];

                Customer customer = new Customer(productId, productName, email, address, contact, dob, gender);
                customers.Add(customer);
            }

            reader.Close();
            con.Close();
            return customers;
        }

        public static int DeleteCustomer(int id)
        {
            SqlConnection con = DBConnector.GetConnection();
            con.Open();

            string query = "delete from customer where id= @id";
            SqlCommand command = new SqlCommand(query, con);

            command.Parameters.AddWithValue("@id", id);
            int rowsAffected = command.ExecuteNonQuery();
            return rowsAffected;
        }
    }
}
