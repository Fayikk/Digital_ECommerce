using Digital_Domain_Layer.Entities;
using Digital_Persistence_Layer.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Digital_Persistence_Layer.Repositories.Interface
{
    public interface IOrderRepository
    {
        Task<BaseResponseModel> CreateOrder(List<Product> products);
        Task<BaseResponseModel> GetOrderByUserId();
    }
}
