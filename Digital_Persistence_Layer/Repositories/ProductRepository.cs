using AutoMapper;
using Digital_Domain_Layer.Entities;
using Digital_Domain_Layer.Extensions;
using Digital_Infrastructure_Layer.DTOs.Product;
using Digital_Persistence_Layer.AppDbContext;
using Digital_Persistence_Layer.Model;
using Digital_Persistence_Layer.Repositories.Interface;
using System.Linq;

namespace Digital_Persistence_Layer.Repositories
{
    public class ProductRepository : Repository<Product>, IProductRepository
    {
        private readonly IMapper _mapper;
        public ProductRepository(ApplicationDbContext context,IMapper mapper) : base(context)
        {
            _mapper = mapper;
        }

        public async Task<BaseResponseModel> AddProduct(ProductDTO productDTO)
        {

            var action = productDTO.Color;
            var actionDescription = action.GetDescription();
            var objMap = _mapper.Map<Product>(productDTO);
            objMap.Color = actionDescription;
            Product product = await Add(objMap);
            if (product is not null)
            {
                return new BaseResponseModel
                {
                    Success = true,
                    Message = "Product created successfully",
                    Result = product
                };
            }
            return new BaseResponseModel
            {
                Success = false,
                Message = "Product created failed",
            };
        }


     

            public async Task<BaseResponseModel> GetAllProducts()
        {
            IEnumerable<Product> products = await GetAll();
            var objMap = _mapper.Map<IEnumerable<GetProductDTO>>(products);
            if (objMap is not null)
            {
                return new BaseResponseModel
                {
                    Success = true,
                    Message = "Products fetched successfully",
                    Result = objMap
                };
            }
            return new BaseResponseModel
            {
                Success = false,
                Message = "Products fetched failed",
            };
        }

        public async Task<BaseResponseModel> GetProductById(Guid id)
        {
           Product product = await GetWhere(x=>x.Id == id,x=>x.ProductImages);

            var objMap = _mapper.Map<GetProductDTO>(product);
            if (objMap is not null)
            {
                return new BaseResponseModel
                {
                    Success = true,
                    Message = "Product fetched successfully",
                    Result = objMap
                };
            }
            return new BaseResponseModel
            {
                Success = false,
                Message = "Product fetched failed",
            };
        }

        public async Task<BaseResponseModel> GetProductsWithPagination(PageAndFilterModel model)
        {
            PagedResult<Product> products = await GetPagedResult(x => (x.ProductName.Contains(model.Keyword)
            || x.ProductDescription.Contains(model.Keyword)
            || x.Color.Contains(model.Keyword)
            || x.SubCategory.CategoryName.Contains(model.Keyword)) && (x.SubCategoryId == model.CategoryId || model.CategoryId == null), 
            x => x.OrderByDescending(x => x.ProductPrice), model.PageNumber,model.PageSize,x=>x.ProductImages);

            if (products.Items is not null)
            {
                return new BaseResponseModel { Exception = null, Message = "Products fetched successfully", Result = products };
            }
            return new BaseResponseModel { Exception = null, Message = "Products not found" };


        }

        public async Task<BaseResponseModel> RemoveProduct(Guid id)
        {
            await Delete(id);
            return new BaseResponseModel
            {
                Success = true,
                Message = "Product deleted successfully",
            };
        }

        public async Task<BaseResponseModel> UpdateProduct(UpdateProductDTO productDTO)
        {
            var objMap = _mapper.Map<Product>(productDTO);
            var result = await Update(productDTO.Id, objMap);
            if (result is not null)
            {
                return new BaseResponseModel
                {
                    Success = true,
                    Message = "Product updated successfully",
                    Result = result
                };
            }
            return new BaseResponseModel
            {
                Success = false,
                Message = "Product updated failed",
            };
        }
    }
}
