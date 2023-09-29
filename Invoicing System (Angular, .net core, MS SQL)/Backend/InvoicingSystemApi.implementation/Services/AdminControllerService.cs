using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Data.Common;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WebApplication1.implementation.Services
{
    public class AdminControllerService
    {
        private readonly SqlConnection _sqlConnection;


        public AdminControllerService(IConfiguration configuration)
        {
            string connectionString = configuration.GetConnectionString("DB");
            _sqlConnection = new SqlConnection(connectionString);
        }

        public List<int> GetInvoiceIDsForDate(string date)
        {
            _sqlConnection.Open();

            string selectInvoiceQuery = "SELECT invoiceID from invoice where Invoicedate =@date";

            SqlCommand command = new SqlCommand(selectInvoiceQuery, _sqlConnection);

            command.Parameters.AddWithValue("@date", date);

            using (SqlDataReader reader = command.ExecuteReader())
            {
                if (reader.Read())
                {
                    List<int> invoiceIDs = new List<int>();
                    do
                    {
                        int invoiceID = reader.GetInt32("invoiceID");
                        invoiceIDs.Add(invoiceID);
                    } while (reader.Read());

                    return invoiceIDs;
                }
                else
                {
                    throw new Exception("Invoice not found.");
                }
            }


        }
    }
}
