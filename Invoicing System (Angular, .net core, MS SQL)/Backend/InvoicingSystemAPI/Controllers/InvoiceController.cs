using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using WebApplication1.implementation.Models;
using WebApplication1.implementation.Services;

namespace WebApplication1.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class InvoiceController : ControllerBase
    {
        private readonly InvoiceControllerService _invoiceControllerService;

        public InvoiceController(InvoiceControllerService invoiceControllerService)
        {
            _invoiceControllerService = invoiceControllerService;
        }
        [HttpPost("AddInvoiceHeader{customerId},{Date}")]
        public async Task<IActionResult> AddInvoiceHeader(int customerId, string Date)
        {
            bool validCId = _invoiceControllerService.CheckCName(customerId);
            string formattedDate = "";
            if (validCId)
            {
                if (DateTime.TryParse(Date, out DateTime date))
                {
                    formattedDate = date.ToString("yyyy-MM-dd");
                }
                else { return Ok("Invalid Date"); }
                int invoiceId = _invoiceControllerService.GenerateInvoiceHeader(formattedDate, customerId);
                return Ok(invoiceId);
            }
            else { return Ok (new { message = "Invalid Id" }); }
        }

        [HttpPost("AddInvoiceItems{invoiceId},{productId},{quantity}")]
        public async Task<IActionResult> AddInvoiceItems(int invoiceId, int productId, int quantity)
        {
            string name = _invoiceControllerService.CheckPName(productId);
            bool stockAvailable = _invoiceControllerService.CheckStockAvailable(productId, quantity);
            if (name == "")
            {
                return Ok (new { message = "Invalid Product ID" });
            }
            else if (!stockAvailable)
            {
                return Ok (new { message = "Insufficient stock" });

            }
            _invoiceControllerService.AddInvoiceItem(invoiceId, productId, quantity);
            return Ok(new { message = "Item Added" });
        }

        [HttpGet("GetInvoice{invoiceId}")]
        public async Task<IActionResult> GetInvoice(int invoiceId)
        {
            return Ok(_invoiceControllerService.PrintInvoice(invoiceId));
        }

        [HttpGet("GetStock{productId}")]
        public async Task<IActionResult> GetStock(int productId)
        {
            return Ok(_invoiceControllerService.GetStock(productId));
        }


    }
}
