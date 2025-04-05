using Digital_Core_Layer.Services.Abstract;
using Digital_Persistence_Layer.Model;
using Digital_Persistence_Layer.Repositories.Interface;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Digital_Core_Layer.Services.Concrete
{
    public class ProductImageService : IProductImageService
    {
        private readonly IProductImageRepository _productImageRepository;
        public ProductImageService(IProductImageRepository productImageRepository)
        {
            _productImageRepository = productImageRepository;
        }

        public async Task<BaseResponseModel> UploadImageAsync(Guid ProductId, List<IFormFile> File)
        {
            var result = await _productImageRepository.UploadImageAsync(ProductId, File);
            return result;
        }
    }
}
