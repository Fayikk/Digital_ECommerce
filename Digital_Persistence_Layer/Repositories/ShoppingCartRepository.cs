using Digital_Domain_Layer.Entities;
using Digital_Persistence_Layer.AppDbContext;
using Digital_Persistence_Layer.Model;
using Digital_Persistence_Layer.Repositories.Interface;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;
using System.Security.Claims;

namespace Digital_Persistence_Layer.Repositories
{
    public class ShoppingCartRepository : Repository<Cart>, IShoppingCartRepository
    {
        private readonly string UserId;
        public ShoppingCartRepository(ApplicationDbContext context,IHttpContextAccessor httpContextAccessor) : base(context)
        {
            UserId = httpContextAccessor.HttpContext.User.FindFirst(ClaimTypes.NameIdentifier).Value;
        }

        public async Task<BaseResponseModel> AddToCart(Guid productId)
        {
            var cart = await GetWhere(x => x.UserId == UserId, x => x.Products);
            if (cart is null)
            {
                var newCart = new Cart
                {
                    UserId = UserId,
                    Products = new List<Product>()
                };
               
                var product = await GetByIdGeneric<Product>(productId);
                newCart.Products.Add(product);
                var result = await Add(newCart);
                if (result is not null)
                {
                    return new BaseResponseModel
                    {
                        Success = true,
                        Message = "Product added to cart successfully",
                        Result = result
                    };
                }
                return new BaseResponseModel
                {
                    Success = false,
                    Message = "Product added to cart failed",
                };
            }
            else
            {
                var product = await GetByIdGeneric<Product>(productId);
                cart.Products.Add(product);
                var result = await Update(cart.Id,cart);
                if (result is not null)
                {
                    return new BaseResponseModel
                    {
                        Success = true,
                        Message = "Product added to cart successfully",
                        Result = result
                    };
                }
                return new BaseResponseModel
                {
                    Success = false,
                    Message = "Product added to cart failed",
                };
            }
        }

        public async Task<BaseResponseModel> GetCartItems()
        {
            var result = await GetWhereWithThenInclude(x => x.UserId == UserId, query => query.Include(x=>x.Products).ThenInclude(x=>x.ProductImages));
            if (result is not null)
            {
                return new BaseResponseModel
                {
                    Success = true,
                    Message = "Cart items fetched successfully",
                    Result = result
                };
            }
            return new BaseResponseModel
            {
                Success = false,
                Message = "Cart items fetched failed",
            };
        }

        public async Task<Cart> GetUserCart()
        {
            var result = await GetWhereWithThenInclude(x => x.UserId == UserId, query => query.Include(x => x.Products).ThenInclude(x => x.ProductImages));
            if (result is not null)
            {
                return result;
            }
            return null;
        }

        public async Task<BaseResponseModel> RemoveCart(Guid cartId)
        {
            var cart = await GetWhere(x=>x.Id == cartId ,x=>x.Products);

            foreach (var item in cart.Products)
            {
               cart.Products.Remove(item);
            }


            if (cart is not null)
            {
                await Delete(cartId);
              
                    return new BaseResponseModel
                    {
                        Success = true,
                        Message = "Cart removed successfully",
                    };
              
               
            }
            return new BaseResponseModel
            {
                Success = false,
                Message = "Cart removed failed",
            };
        }

        public async Task<BaseResponseModel> RemoveFromCart(Guid productId)
        {
            var cart = await GetWhere(x => x.UserId == UserId, x => x.Products);
            if (cart is not null)
            {
                var product = cart.Products.FirstOrDefault(x => x.Id == productId);
                if (product is not null)
                {
                    cart.Products.Remove(product);
                    var result = Update(cart.Id, cart).Result;
                    if (result is not null)
                    {
                        return new BaseResponseModel
                        {
                            Success = true,
                            Message = "Product removed from cart successfully",
                            Result = result
                        };
                    }
                    return new BaseResponseModel
                    {
                        Success = false,
                        Message = "Product removed from cart failed",
                    };
                }
                return new BaseResponseModel
                {
                    Success = false,
                    Message = "Product not found in cart",
                };
            }
            return new BaseResponseModel
            {
                Success = false,
                Message = "Product removed from cart failed",
            };
        }
    }
}
