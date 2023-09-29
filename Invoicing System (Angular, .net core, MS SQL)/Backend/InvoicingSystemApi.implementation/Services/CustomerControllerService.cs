using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Common;
using System.Data.SqlClient;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using WebApplication1.implementation.Models;

namespace WebApplication1.implementation.Services
{
    public class CustomerControllerService
    {
        private readonly SqlConnection _sqlConnection;


        public CustomerControllerService(IConfiguration configuration)
        {
            string connectionString = configuration.GetConnectionString("DB");
            _sqlConnection = new SqlConnection(connectionString);
        }

        public int AddCustomer(Customer _customer)
        {
            int generatedID = 0;

            using (SqlCommand command = new SqlCommand("AddCustomer", _sqlConnection))
            {
                command.CommandType = CommandType.StoredProcedure;

                command.Parameters.AddWithValue("@name", _customer.Name);
                command.Parameters.AddWithValue("@email", _customer.Email);
                command.Parameters.AddWithValue("@address", _customer.Address);
                command.Parameters.AddWithValue("@contact", _customer.Contact);
                command.Parameters.AddWithValue("@dob", _customer.Dob);
                command.Parameters.AddWithValue("@gender", _customer.Gender);

                _sqlConnection.Open();
                
                object result = command.ExecuteScalar();

                if (result != null && int.TryParse(result.ToString(), out int convertedID))
                {
                    generatedID = convertedID;
                }
                _sqlConnection.Close();
            }
            return generatedID;
        }

        public string GetCName(int id)
        {
            string name = "";

            using (SqlCommand command = new SqlCommand("GetCName", _sqlConnection))
            {
                command.CommandType = CommandType.StoredProcedure;

                command.Parameters.AddWithValue("@id", id);

                _sqlConnection.Open();

                using (SqlDataReader reader = command.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        name = reader.GetString(0);
                    }
                }
            }
            return name;
        }
        public Customer GetCustomer(int id)
        {
            Customer customer = null;

            SqlCommand command = new SqlCommand("GetCustomerById", _sqlConnection);

            command.CommandType = CommandType.StoredProcedure;

            command.Parameters.AddWithValue("@id", id);

            _sqlConnection.Open();

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

                customer = new Customer()
                {
                    Id = id,
                    Name = productName,
                    Email = email,
                    Address = address,
                    Contact = contact,
                    Dob = dob,
                    Gender = gender,
                };
            }
            return customer;
        }

        public List<Customer> GetCustomers()
        {
            List<Customer> customers = new List<Customer>();

            _sqlConnection.Open();
            SqlCommand command = new SqlCommand("GetCustomers", _sqlConnection);
            command.CommandType = CommandType.StoredProcedure;
            SqlDataReader reader = command.ExecuteReader();

            while (reader.Read())
            {
                int Id = (int)reader["id"];
                string productName = (string)reader["name"];
                string email = (string)reader["email"];
                string address = (string)reader["address"];
                int contact = (int)reader["contact"];
                string dob = (string)reader["dob"];
                string gender = (string)reader["gender"];

                Customer customer = new Customer()
                {
                    Id = Id,
                    Name = productName,
                    Email = email,
                    Address = address,
                    Contact = contact,
                    Dob = dob,
                    Gender = gender,
                };
                customers.Add(customer);
            }

            reader.Close();
            _sqlConnection.Close();
            return customers;
        }

        public int DeleteCustomer(int id)
        {
            _sqlConnection.Open();

            SqlCommand command = new SqlCommand("DeleteCustomer", _sqlConnection);
            command.CommandType = CommandType.StoredProcedure;
            command.Parameters.AddWithValue("@id", id);
            int rowsAffected = command.ExecuteNonQuery();
            _sqlConnection.Close();
            return rowsAffected;
        }
    }
}
