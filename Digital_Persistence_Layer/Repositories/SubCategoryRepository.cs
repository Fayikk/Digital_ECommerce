using AutoMapper;
using Digital_Domain_Layer.Entities;
using Digital_Infrastructure_Layer.DTOs;
using Digital_Persistence_Layer.AppDbContext;
using Digital_Persistence_Layer.Model;
using Digital_Persistence_Layer.Repositories.Interface;

namespace Digital_Persistence_Layer.Repositories
{
    public class SubCategoryRepository : Repository<SubCategory>, ISubCategoryRepository
    {
        private readonly IMapper _mapper;
        public SubCategoryRepository(ApplicationDbContext context,IMapper mapper) : base(context)
        {
            _mapper = mapper;
        }

        public async Task<BaseResponseModel> CreateSubCategory(SubCategoryDTO subCategoryDTO)
        {
            var objMap = _mapper.Map<SubCategory>(subCategoryDTO);

            var result = await Add(objMap);
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

        public async Task<BaseResponseModel> GetSubCategories()
        {
            var result = await GetAll();
            if (result is not null)
            {
                return new BaseResponseModel
                {
                    Success = true,
                    Message = "Main Category fetched successfully",
                    Result = result
                };
            }
            return new BaseResponseModel
            {
                Success = false,
                Message = "Main Category fetched failed",
            };
        }
    }
}
