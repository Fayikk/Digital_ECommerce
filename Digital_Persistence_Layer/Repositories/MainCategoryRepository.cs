using Digital_Domain_Layer.Entities;
using Digital_Infrastructure_Layer.DTOs;
using Digital_Persistence_Layer.AppDbContext;
using Digital_Persistence_Layer.Model;
using Digital_Persistence_Layer.Repositories.Interface;

namespace Digital_Persistence_Layer.Repositories
{
    public class MainCategoryRepository : Repository<MainCategory>, IMainCategoryRepository
    {
        public MainCategoryRepository(ApplicationDbContext context) : base(context)
        {
        }

        public async Task<BaseResponseModel> CreateMainCategory(MainCategoryDTO mCategory)
        {
            var result = await Add(new MainCategory
            {
                CategoryName = mCategory.CategoryName,
                CategoryDescription = mCategory.CategoryName
            });
            if (result is not null)
            {
                return new BaseResponseModel
                {
                    Success = true,
                    Message = "Main Category created successfully",
                    Result = result
                };
            }
            return new BaseResponseModel
            {
                Success = false,
                Message = "Main Category created failed",
            };
        }

        public async Task<BaseResponseModel> GetAllMainCategories()
        {
            var result = await GetWithIncludeProperties(x=>x.SubCategories);
            if (result is not null)
            {
                return new BaseResponseModel
                {
                    Success = true,
                    Message = "Main Categories fetched successfully",
                    Result = result
                };
            }
            return new BaseResponseModel
            {
                Success = false,
            };
        }
    }
}
