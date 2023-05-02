using Microsoft.AspNetCore.Mvc;
using netCore.Hangfire.Application.Requests;
using netCore.Hangfire.Application.Services;
using netCore.Hangfire.Models.Entities;

namespace netCore.Hangfire.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductsController : ControllerBase
    {
        private readonly IProductService _productService;

        public ProductsController(IProductService productService)
        {
            _productService = productService;
        }

        [HttpGet]
        public async Task<ActionResult<List<Product>>> GetAllProducts()
        {
            var response = await _productService.GetAllProducts();
            return Ok(response);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Product>> GetProductById([FromRoute]Guid id)
        {
            var response = await _productService.GetProductById(id);
            return Ok(response);
        }

        [HttpPost]
        public async Task<Product> CreateProduct([FromBody] CreateProductRequest request)
        {
            var response = await _productService.CreateProduct(request);
            return response;
        }

        [HttpPut("{id}")]
        public async Task<Product> UpdateProduct([FromRoute]Guid id, [FromBody] UpdateProductRequest request)
        {
            var response = await _productService.UpdateProduct(id, request);
            return response;
        }

        [HttpDelete("{id}")]
        public async Task<Product> DeleteProduct([FromRoute]Guid id)
        {
            var response = await _productService.DeleteProduct(id);
            return response;
        }
    }
}
