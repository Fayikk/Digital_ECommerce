using Digital_Core_Layer.Services.Abstract;
using Digital_Infrastructure_Layer.DTOs;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Digital_API_Layer.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MainCategoryController : ControllerBase
    {
        private readonly IMainCategoryService mainCategoryService;
        public MainCategoryController(IMainCategoryService mainCategoryService)
        {
            this.mainCategoryService = mainCategoryService;
        }

        [HttpPost]
        public async Task<ActionResult> CreateMainCategory([FromBody] MainCategoryDTO categoryDTO)
        {
            var response = await mainCategoryService.CreateMainCategory(categoryDTO);
            if (response != null)
            {
                return Ok(response);
            }
            return BadRequest();
        }

        [HttpGet]
        public async Task<ActionResult> GetMainCategories()
        {
            var response = await mainCategoryService.GetMainCategories();
            if (response != null)
            {
                return Ok(response);
            }
            return BadRequest();
        }
    }
}