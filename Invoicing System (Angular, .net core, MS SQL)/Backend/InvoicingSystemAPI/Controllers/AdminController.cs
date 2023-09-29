using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using WebApplication1.implementation.Services;
using WebApplication1.implementation.Models;

namespace WebApplication1.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AdminController : ControllerBase
    {
        private readonly AdminControllerService _adminControllerSerivce;
        private readonly InvoiceControllerService _invoiceControllerSerivce;

        public AdminController(AdminControllerService adminControllerSerivce, InvoiceControllerService invoiceControllerService)
        {
            _adminControllerSerivce = adminControllerSerivce;
            _invoiceControllerSerivce = invoiceControllerService;

        }

        [HttpGet("{Date}")]
        public async Task<IActionResult> GetInvoices(string Date)
        {
            string formattedDate = "";
            if (DateTime.TryParse(Date, out DateTime date))
            {
                formattedDate = date.ToString("yyyy-MM-dd");
                List<int> invioceIds = _adminControllerSerivce.GetInvoiceIDsForDate(formattedDate);
                List<Invoice> invoices = new List<Invoice>();
                foreach (int invioceId in invioceIds)
                {
                    Invoice invoice = _invoiceControllerSerivce.GetInvoice(invioceId);
                    invoices.Add(invoice);
                }
                return Ok(invoices);
            }
            else
            {
                return Ok("Invalid date format. Please enter a valid date in the format yyyy-MM-dd.");
            }
        }
    }
}
