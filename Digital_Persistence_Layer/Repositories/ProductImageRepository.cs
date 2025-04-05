using Digital_Domain_Layer.Entities;
using Digital_Persistence_Layer.AppDbContext;
using Digital_Persistence_Layer.Model;
using Digital_Persistence_Layer.Repositories.Interface;
using Microsoft.AspNetCore.Http;

namespace Digital_Persistence_Layer.Repositories
{
    public class ProductImageRepository : Repository<ProductImage>, IProductImageRepository
    {
        public ProductImageRepository(ApplicationDbContext context) : base(context)
        {
        }

        public async Task<BaseResponseModel> UploadImageAsync(Guid ProductId, List<IFormFile> File)
        {
            if (File.Count == 0 || File is null)
            {
                return new BaseResponseModel()
                {
                    Success = false,
                    Message = "No file selected"
                };
            }

            var uploadDirectory = Path.Combine("wwwroot","images");
            if (!Directory.Exists(uploadDirectory))
            {
                Directory.CreateDirectory(uploadDirectory);
            }


            var uploadImages = new List<ProductImage>();
            foreach (var item in File)
            {
                var filePath = Path.Combine(uploadDirectory, item.FileName);
                using (var stream = new FileStream(filePath, FileMode.Create))
                {
                    await item.CopyToAsync(stream);
                }
                uploadImages.Add(new ProductImage
                {
                    ProductId = ProductId,
                    ImageUrl = filePath
                });
            }
            var result = await AddRange(uploadImages);
            if (result is not null)
            {
                return new BaseResponseModel
                {
                    Success = true,
                    Message = "Image uploaded successfully",
                    Result = result
                };
            }
            return new BaseResponseModel
            {
                Success = false,
                Message = "Image uploaded failed",
            };
        }
    }
}
