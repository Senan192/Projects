using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;

namespace invoice_system.Controllers
{
    public class DBConnector
    {
        public static SqlConnection GetConnection()
        {
            SqlConnection con = new SqlConnection(@"Data Source=.;Initial Catalog=invoice_system;Integrated Security=True");
            return con;
        }
    }
}
