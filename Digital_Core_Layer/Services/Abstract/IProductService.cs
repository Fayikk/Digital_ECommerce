using Digital_Infrastructure_Layer.DTOs.Product;
using Digital_Persistence_Layer.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Digital_Core_Layer.Services.Abstract
{
    public interface IProductService
    {
        Task<BaseResponseModel> GetAllProducts();
        Task<BaseResponseModel> GetProductById(Guid id);
        Task<BaseResponseModel> RemoveProduct(Guid id);
        Task<BaseResponseModel> AddProduct(ProductDTO productDTO);
        Task<BaseResponseModel> UpdateProduct(UpdateProductDTO productDTO);
        Task<BaseResponseModel> GetProductsWithPagination(PageAndFilterModel model);
    }
}
