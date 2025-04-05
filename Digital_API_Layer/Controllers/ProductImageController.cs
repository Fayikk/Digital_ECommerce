﻿using Digital_Core_Layer.Services.Abstract;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Digital_API_Layer.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductImageController : ControllerBase
    {
        private readonly IProductImageService _productImageService;
        public ProductImageController(IProductImageService productImageService)
        {
            _productImageService = productImageService;
        }

        [HttpPost("UploadImage")]
        public async Task<IActionResult> UploadImage([FromForm]ProductImageDTO productImageDTO)
        {
            var result = await _productImageService.UploadImageAsync(productImageDTO.ProductId, productImageDTO.File);
            return Ok(result);
        }
    }
    public class ProductImageDTO
    {
        [FromForm]
        public Guid ProductId { get; set; }
        [FromForm]
        public List<IFormFile> File { get; set; }

    }
}