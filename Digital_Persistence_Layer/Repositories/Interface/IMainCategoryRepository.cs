using Digital_Domain_Layer.Entities;
using Digital_Infrastructure_Layer.DTOs;
using Digital_Persistence_Layer.Model;

namespace Digital_Persistence_Layer.Repositories.Interface
{
    public interface IMainCategoryRepository
    {
        Task<BaseResponseModel> CreateMainCategory(MainCategoryDTO mCategory);
        Task<BaseResponseModel> GetAllMainCategories();
    }
}
