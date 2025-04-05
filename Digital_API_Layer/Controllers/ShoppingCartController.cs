using Digital_Core_Layer.Services.Abstract;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Digital_API_Layer.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ShoppingCartController : ControllerBase
    {
        private readonly IShoppingCartService _shoppingCartService;
        public ShoppingCartController(IShoppingCartService shoppingCartService)
        {
            _shoppingCartService = shoppingCartService;
        }

        [Authorize(AuthenticationSchemes ="Bearer")]
        [HttpPost("AddCart")]
        public async Task<IActionResult> AddToCart(Guid productId)
        {
            var result = await _shoppingCartService.AddToCart(productId);
            return Ok(result);
        }
        [Authorize(AuthenticationSchemes = "Bearer")]

        [HttpGet("GetCart")]
        public async Task<IActionResult> GetCartItems()
            {
            var result = await _shoppingCartService.GetCartItems();
            return Ok(result);
        }
        
        [Authorize(AuthenticationSchemes = "Bearer")]

        [HttpDelete("RemoveFromCart")]
        public async Task<IActionResult> RemoveFromCart(Guid productId)
        {
            var result = await _shoppingCartService.RemoveFromCart(productId);
            return Ok(result);
        }


        [Authorize(AuthenticationSchemes = "Bearer")]

        [HttpDelete("RemoveCart")]
        public async Task<IActionResult> RemoveCart(Guid cartId)
        {
            var result = await _shoppingCartService.RemoveCart(cartId);
            return Ok(result);
        }
    }
}
