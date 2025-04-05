using Digital_Core_Layer.Services.Abstract;
using Digital_Persistence_Layer.Model;
using Digital_Persistence_Layer.Repositories.Interface;

namespace Digital_Core_Layer.Services.Concrete
{
    public class OrderService : IOrderService
    {
        private readonly IShoppingCartRepository _shoppingCartRepository;
        private readonly IOrderRepository _orderRepository;
        public OrderService(IOrderRepository orderRepository, IShoppingCartRepository shoppingCartRepository)
        {
            _orderRepository = orderRepository;
            _shoppingCartRepository = shoppingCartRepository;
        }

        public async Task<BaseResponseModel> CreateOrder()
        {
            var shoppingCart = await _shoppingCartRepository.GetUserCart();
            if (shoppingCart is not null)
            {
                var order = await _orderRepository.CreateOrder(shoppingCart.Products.ToList());
                if (order.Success)
                {
                    return new BaseResponseModel
                    {
                        Success = true,
                        Message = "Order created successfully",
                        Result = order.Result
                    };
                }
            }

            return new BaseResponseModel
            {
                Success = false,
                Message = "Order creation failed",
            };
        }

        public async Task<BaseResponseModel> GetUserOrders()
        {
            var orders = await _orderRepository.GetOrderByUserId();
            return orders;
        }
        
    }
}
