using Digital_Core_Layer.Services.Abstract;
using Digital_Persistence_Layer.Model;
using Digital_Persistence_Layer.Repositories.Interface;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Digital_API_Layer.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly IUserService _userService;
        public UserController(IUserService userService)
        {
            _userService = userService;
        }

        [HttpPost("SignUp")]
        public async Task<ActionResult> SignUp([FromBody]RegisterModel model)
        {
            var response = await _userService.Register(model);
           
                return Ok(response);
           
        }

        [HttpPost("SignIn")]
        public async Task<ActionResult> SignIn([FromBody] LoginModel model)
        {
            var response = await _userService.Login(model);
           
                return Ok(response);
         
        }

    }
}
