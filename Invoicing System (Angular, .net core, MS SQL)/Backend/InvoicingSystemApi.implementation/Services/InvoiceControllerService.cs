using Microsoft.Extensions.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Text;
using WebApplication1.implementation.Models;

namespace WebApplication1.implementation.Services
{
    public class InvoiceControllerService
    {
        private readonly SqlConnection _sqlConnection;
        private readonly CustomerControllerService _customerControllerService;
        private readonly ProductControllerService _productControllerService;

        public InvoiceControllerService(IConfiguration configuration)
        {
            string connectionString = configuration.GetConnectionString("DB");
            _sqlConnection = new SqlConnection(connectionString);
            _customerControllerService = new CustomerControllerService(configuration);
            _productControllerService = new ProductControllerService(configuration);
        }

        public Boolean CheckCName(int id)
        {
            String name = _customerControllerService.GetCName(id);
            if (name != "")
            {
                return true;
            }
            else { return false; }
        }
        public int GenerateInvoiceHeader(String invoiceDate, int customerID)
        {
            _sqlConnection.Open();

            SqlCommand command = new SqlCommand("GenerateInvoiceHeader", _sqlConnection);
            command.CommandType = CommandType.StoredProcedure;
            command.Parameters.AddWithValue("@customerID", customerID);
            command.Parameters.AddWithValue("@invoiceDate", invoiceDate);

            int generatedInvoiceID = 0;

            object result = command.ExecuteScalar();

            if (result != null && int.TryParse(result.ToString(), out int convertedID))
            {
                generatedInvoiceID = convertedID;
            }
            _sqlConnection.Close();
            return generatedInvoiceID;
        }

        public void UpdatePQuantity(int id, int stockUsed)
        {
            int previousStock = _productControllerService.GetStock(id);
            int newStock = previousStock - stockUsed;
            _productControllerService.UpdateQuantity(id, newStock);
        }

        public string CheckPName(int id)
        {
            String name = _productControllerService.GetPName(id);
            return name;
        }

        public bool CheckStockAvailable(int id, int quantity)
        {
            bool avaiable = _productControllerService.CheckStockAvailable(id, quantity);
            return avaiable;
        }

        public int GetStock(int id)
        {
            return _productControllerService.GetStock(id);
        }

        public void AddInvoiceItem(int invoiceID, int productId, int quantityTmp)
        {
            int pID = productId;
            int unitP = _productControllerService.GetPPrice(pID);
            int quantity = quantityTmp;
            int totalP = unitP * quantity;
            string productName = _productControllerService.GetPName(pID);

            _sqlConnection.Open();

            SqlCommand command = new SqlCommand("AddInvoiceItem", _sqlConnection);
            command.CommandType = CommandType.StoredProcedure;
                command.Parameters.AddWithValue("@invoiceID", invoiceID);
                command.Parameters.AddWithValue("@productID", pID);
                command.Parameters.AddWithValue("@productName", productName);
                command.Parameters.AddWithValue("@quantity", quantity);
                command.Parameters.AddWithValue("@unitP", unitP);
                command.Parameters.AddWithValue("@totalP", totalP);
                command.ExecuteNonQuery();

            UpdatePQuantity(pID, quantity);
            _sqlConnection.Close();
        }

        public Invoice PrintInvoice(int iID)
        {
            Invoice invoice = GetInvoice(iID);
            return invoice;
        }

        public Invoice GetInvoice(int invoiceID)
        {
            _sqlConnection.Open();
            SqlCommand command = new SqlCommand("GetInvoiceById", _sqlConnection);
            command.CommandType = CommandType.StoredProcedure;

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
                        string productName = reader.GetString("productName");
                        int quantity = reader.GetInt32("quantity");
                        int unitPrice = reader.GetInt32("unitP");
                        int totalPrice = reader.GetInt32("totalP");

                        InvoiceItems item = new InvoiceItems()
                        {
                            ProductID = productID,
                            ProductName = productName,
                            UnitPrice = unitPrice,
                            Quantity = quantity,
                            TotalPrice = totalPrice,
                        };
                        items.Add(item);
                    } while (reader.Read());

                    _sqlConnection.Close();
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
