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
    public class AdminController
    {
        public static List<int> GetInvoiceIDsForDate(string date)
        {
            using (SqlConnection con = DBConnector.GetConnection())
            {
                con.Open();

                string selectInvoiceQuery = "SELECT invoiceID from invoice where Invoicedate =@date";

                using (SqlCommand command = new SqlCommand(selectInvoiceQuery, con))
                {
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
    }
}
