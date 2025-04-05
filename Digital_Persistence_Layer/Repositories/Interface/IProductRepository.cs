using Digital_Domain_Layer.Entities;
using Digital_Infrastructure_Layer.DTOs.Product;
using Digital_Persistence_Layer.Model;

namespace Digital_Persistence_Layer.Repositories.Interface
{
    public interface IProductRepository
    {
        Task<BaseResponseModel> GetAllProducts();
        Task<BaseResponseModel> GetProductById(Guid id);
        Task<BaseResponseModel> RemoveProduct(Guid id);
        Task<BaseResponseModel> AddProduct(ProductDTO productDTO);
        Task<BaseResponseModel> UpdateProduct(UpdateProductDTO productDTO);
        Task<BaseResponseModel> GetProductsWithPagination(PageAndFilterModel model);
    }




}
