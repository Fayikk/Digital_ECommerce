using Digital_Core_Layer.Services.Abstract;
using Digital_Infrastructure_Layer.DTOs;
using Digital_Persistence_Layer.Model;
using Digital_Persistence_Layer.Repositories.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Digital_Core_Layer.Services.Concrete
{
    public class MainCategoryService : IMainCategoryService
    {
        private readonly IMainCategoryRepository _mainCategoryRepsoitory;
        public MainCategoryService(IMainCategoryRepository mainCategoryRepository)
        {
            _mainCategoryRepsoitory = mainCategoryRepository;
        }

        public async Task<BaseResponseModel> CreateMainCategory(MainCategoryDTO categoryDTO)
        {
            var result = await _mainCategoryRepsoitory.CreateMainCategory(categoryDTO);
            return result;
        }

        public async Task<BaseResponseModel> GetMainCategories()
        {
            var result = await _mainCategoryRepsoitory.GetAllMainCategories();
            return result;
        }
    }
}
