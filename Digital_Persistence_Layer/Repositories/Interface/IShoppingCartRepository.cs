using Digital_Domain_Layer.Entities;
using Digital_Persistence_Layer.Model;

namespace Digital_Persistence_Layer.Repositories.Interface
{
    public interface IShoppingCartRepository
    {
        Task<BaseResponseModel> AddToCart(Guid productId);
        Task<BaseResponseModel> GetCartItems();
        Task<BaseResponseModel> RemoveFromCart(Guid productId);
        Task<BaseResponseModel> RemoveCart(Guid cartId);
        Task<Cart> GetUserCart();
    }
}
