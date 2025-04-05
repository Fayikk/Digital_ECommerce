using Digital_Persistence_Layer.Model;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Digital_Core_Layer.Services.Abstract
{
    public interface IProductImageService
    {
        Task<BaseResponseModel> UploadImageAsync(Guid ProductId, List<IFormFile> File);
    }
}
