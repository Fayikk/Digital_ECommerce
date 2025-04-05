using Digital_Infrastructure_Layer.DTOs;
using Digital_Persistence_Layer.Model;

namespace Digital_Core_Layer.Services.Abstract
{
    public interface IMainCategoryService
    {
        Task<BaseResponseModel> CreateMainCategory(MainCategoryDTO categoryDTO);
        Task<BaseResponseModel> GetMainCategories();
    }
}
