using Digital_Core_Layer.Services.Abstract;
using Digital_Persistence_Layer.Model;
using Digital_Persistence_Layer.Repositories.Interface;

namespace Digital_Core_Layer.Services.Concrete
{
    public class ShoppingCartService : IShoppingCartService
    {
        private readonly IShoppingCartRepository _shoppingCartRepository;

        public ShoppingCartService(IShoppingCartRepository shoppingCartRepository)
        {
            _shoppingCartRepository = shoppingCartRepository;
        }

        public async Task<BaseResponseModel> AddToCart(Guid productId)
        {
           var result = await _shoppingCartRepository.AddToCart(productId);
            return result;
        }

        public async Task<BaseResponseModel> GetCartItems()
        {
            var result = await _shoppingCartRepository.GetCartItems();
            return result;
        }

        public async Task<BaseResponseModel> RemoveCart(Guid cartId)
        {
            var result = await _shoppingCartRepository.RemoveCart(cartId);
            return result;
        }

        public async Task<BaseResponseModel> RemoveFromCart(Guid productId)
        {
            var result = await _shoppingCartRepository.RemoveFromCart(productId);
            return result;
        }
    }
}
