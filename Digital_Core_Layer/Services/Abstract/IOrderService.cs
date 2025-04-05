using Digital_Persistence_Layer.Model;

namespace Digital_Core_Layer.Services.Abstract
{
    public interface IOrderService
    {
        Task<BaseResponseModel> CreateOrder();
        Task<BaseResponseModel> GetUserOrders();
    }
}
