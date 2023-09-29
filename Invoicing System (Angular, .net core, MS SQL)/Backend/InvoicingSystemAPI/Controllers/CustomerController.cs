using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Data;
using System.Data.SqlClient;
using WebApplication1.implementation.Services;
using WebApplication1.implementation.Models;


namespace WebApplication1.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CustomerController : ControllerBase
    {
        private readonly CustomerControllerService _customerControllerService;

        public CustomerController(CustomerControllerService customerControllerService)
        {
            _customerControllerService = customerControllerService;
        }

        [HttpPost]
        public async Task<IActionResult> AddCustomer([FromBody] Customer customer)
        {
            int generatedId = _customerControllerService.AddCustomer(customer);
            return Ok(generatedId);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetCustomer(int id)
        {
            return Ok(_customerControllerService.GetCustomer(id));
        }

        [HttpGet]
        public async Task<IActionResult> GetCustomers()
        {
            return Ok(_customerControllerService.GetCustomers());
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteCustomer(int id)
        {

            return Ok(_customerControllerService.DeleteCustomer(id));
        }
    }
}
