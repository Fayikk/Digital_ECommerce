using Digital_Infrastructure_Layer.DTOs;
using Digital_Persistence_Layer.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Digital_Core_Layer.Services.Abstract
{
    public interface ISubCategoryService
    {
        Task<BaseResponseModel> CreateSubCategory(SubCategoryDTO subCategoryDTO);
        Task<BaseResponseModel> GetSubCategories();
    }
}
