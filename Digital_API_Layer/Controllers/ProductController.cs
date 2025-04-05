using Digital_Core_Layer.Services.Abstract;
using Digital_Infrastructure_Layer.DTOs.Product;
using Digital_Persistence_Layer.Model;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Digital_API_Layer.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductController : ControllerBase
    {
        private readonly IProductService productService;
        public ProductController(IProductService productService)
        {
            this.productService = productService;
        }

        [HttpPost("Create")]
        public async Task<IActionResult> CreateProduct(ProductDTO productDTO)
        {
            var result = await productService.AddProduct(productDTO);
            return Ok(result);
        }

        [HttpGet("GetAll")]
        public async Task<IActionResult> GetAllProducts()
        {
            var result = await productService.GetAllProducts();
            return Ok(result);
        }

        [HttpGet("GetById")]
        public async Task<IActionResult> GetProductById(Guid id)
        {
            var result = await productService.GetProductById(id);
            return Ok(result);
        }

        [HttpDelete("Delete")]
        public async Task<IActionResult> DeleteProduct(Guid id)
        {
            var result = await productService.RemoveProduct(id);
            return Ok(result);
        }

        [HttpPut("Update")]
        public async Task<IActionResult> UpdateProduct(UpdateProductDTO productDTO)
        {
            var result = await productService.UpdateProduct(productDTO);
            return Ok(result);
        }

        [HttpPost("GetWithPagination")]
        public async Task<IActionResult> GetProductsWithPagination(PageAndFilterModel model)
        {
            var result = await productService.GetProductsWithPagination(model);
            return Ok(result);
        }

    }
}
