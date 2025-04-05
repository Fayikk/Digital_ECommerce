using Digital_Domain_Layer.Entities;
using Digital_Persistence_Layer.AppDbContext;
using Digital_Persistence_Layer.Model;
using Digital_Persistence_Layer.Repositories.Interface;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;
using System.Security.Claims;

namespace Digital_Persistence_Layer.Repositories
{
    public class OrderRepository : Repository<Order>, IOrderRepository
    {
        private readonly string UserId;
        public OrderRepository(ApplicationDbContext context,IHttpContextAccessor contextAccessor) : base(context)
        {
            UserId = contextAccessor.HttpContext.User.FindFirst(ClaimTypes.NameIdentifier).Value;
        }

        public async Task<BaseResponseModel> CreateOrder(List<Product> products)
        {
            var result = await Add(new Order
            {
                UserId = UserId,
                Products = new List<Product>(products)
            });

            if (result is not null)
            {
                return new BaseResponseModel
                {
                    Success = true,
                    Message = "Order created successfully",
                    Result = result
                };
            }
            return new BaseResponseModel
            {
                Success = false,
                Message = "Order created failed",
            };

        }

        public async Task<BaseResponseModel> GetOrderByUserId()
        {
            var result = await GetAllWhere(x => x.UserId == UserId && x.Products.Count>0, x => x.Include(x=>x.Products).ThenInclude(x=>x.ProductImages));
            if (result is not null)
            {
                return new BaseResponseModel
                {
                    Success = true,
                    Message = "Order fetched successfully",
                    Result = result
                };
            }
            return new BaseResponseModel
            {
                Success = false,
                Message = "Order fetched failed",
            };
        }
    }
}
