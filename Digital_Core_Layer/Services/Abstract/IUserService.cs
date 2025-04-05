using Digital_Persistence_Layer.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Digital_Core_Layer.Services.Abstract
{
    public interface IUserService
    {
        Task<BaseResponseModel> Login(LoginModel model);
        Task<BaseResponseModel> Register(RegisterModel model);


    }
}
