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
    public class SubCategoryService : ISubCategoryService
    {
        private readonly ISubCategoryRepository _subCategoryRepository;
        public SubCategoryService(ISubCategoryRepository subCategoryRepository)
        {
            _subCategoryRepository = subCategoryRepository;
        }

        public async Task<BaseResponseModel> CreateSubCategory(SubCategoryDTO subCategoryDTO)
        {
            var result = await _subCategoryRepository.CreateSubCategory(subCategoryDTO);
            return result;
        }

        public async Task<BaseResponseModel> GetSubCategories()
        {
            var result = await _subCategoryRepository.GetSubCategories();
            return result;
        }
    }
}
