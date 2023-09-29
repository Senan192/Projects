using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using WebApplication1.implementation.Models;
using WebApplication1.implementation.Services;

namespace WebApplication1.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductController : ControllerBase
    {
        private readonly ProductControllerService _productControllerService;

        public ProductController(ProductControllerService productControllerService)
        {
            _productControllerService = productControllerService;
        }

        [HttpPost]
        public async Task<IActionResult> AddProduct([FromBody] Product product)
        {
            int generatedId = _productControllerService.AddProduct(product);
            return Ok(generatedId);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetCustomer(int id)
        {
            return Ok(_productControllerService.GetProduct(id));
        }

        [HttpGet]
        public async Task<IActionResult> GetProducts()
        {
            return Ok(_productControllerService.GetProducts());
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteProduct(int id)
        {
            return Ok(_productControllerService.DeleteProduct(id));
        }

        [HttpPut("{id},{quantity}")]
        public async Task<IActionResult> UpdateQuantity(int id, int quantity)
        {
            return Ok(_productControllerService.UpdateQuantity(id, quantity));
        }
    }
}
