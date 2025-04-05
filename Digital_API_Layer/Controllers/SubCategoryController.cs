using Digital_Core_Layer.Services.Abstract;
using Digital_Infrastructure_Layer.DTOs;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Digital_API_Layer.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SubCategoryController : ControllerBase
    {
        private readonly ISubCategoryService subCategoryService;
        public SubCategoryController(ISubCategoryService subCategoryService)
        {
            this.subCategoryService = subCategoryService;
        }

        [HttpPost]
        public async Task<ActionResult> CreateSubCategory([FromBody] SubCategoryDTO subCategoryDTO)
        {
            var response = await subCategoryService.CreateSubCategory(subCategoryDTO);
            if (response != null)
            {
                return Ok(response);
            }
            return BadRequest();
        }

        [HttpGet("SubCategories")]
        public async Task<ActionResult> GetSubCategories()
        {
            var response = await subCategoryService.GetSubCategories();
            if (response != null)
            {
                return Ok(response);
            }
            return BadRequest();
        }
    }
}
