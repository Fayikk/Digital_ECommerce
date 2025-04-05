using Digital_Persistence_Layer.Model;
using Microsoft.AspNetCore.Http;

namespace Digital_Persistence_Layer.Repositories.Interface
{
    public interface IProductImageRepository
    {
        Task<BaseResponseModel> UploadImageAsync(Guid ProductId, List<IFormFile> File);
    }
}
