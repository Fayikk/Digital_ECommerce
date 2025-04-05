using Digital_Persistence_Layer.Model;

namespace Digital_Core_Layer.Services.Abstract
{
    public interface IShoppingCartService
    {
        Task<BaseResponseModel> AddToCart(Guid productId);
        Task<BaseResponseModel> GetCartItems();
        Task<BaseResponseModel> RemoveFromCart(Guid productId);
        Task<BaseResponseModel> RemoveCart(Guid cartId);
    }
}
