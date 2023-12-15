using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using tehnohem_api.Model;
using tehnohem_api.Services.Interface;

namespace tehnohem_api.Controllers
{
    [Route("api/[controller]/")]
    [ApiController]
    public class ProductController : ControllerBase
    {
        private IProductService productService;

        public ProductController(IProductService productService)
        {
            this.productService = productService;
        }

        [HttpGet("all")]
        public ICollection<Product> getAllProducts() { 
            return productService.GetAllProducts();
        }

        [HttpGet("{id}")]
        public Product getProductById(int id)
        {
            return productService.GetProductById(id);
        }

        [HttpDelete("delete/{id}")]
        public IActionResult Delete(int id)
        {
            this.productService.DeleteProduct(id);
            return Ok();
        }

        [HttpPost("add")]
        public IActionResult AddNewProduct(Product product) {
            this.productService.Add(product);
            return Ok();
        }

        [HttpPut("update")]
        public IActionResult UpdateProduct(Product product) {
            this.productService.UpdateProduct(product);
            return Ok();
        }
    }
}
