using Digital_Core_Layer.Services.Abstract;
using Digital_Persistence_Layer.Model;
using Digital_Persistence_Layer.Repositories.Interface;
using FluentValidation;
using FluentValidation.Results;
using Microsoft.AspNetCore.Mvc.ModelBinding;

namespace Digital_Core_Layer.Services.Concrete
{
    public class UserService : IUserService
    {
        private readonly IUserRepository _userRepository;
        private readonly IValidator<RegisterModel> _registerValidator;
        private readonly IValidator<LoginModel> _loginValidator;
        public UserService(IUserRepository userRepository, IValidator<LoginModel> loginValidator,IValidator<RegisterModel> registerValidator)
        {
            _registerValidator = registerValidator;
            _userRepository = userRepository;
            _loginValidator = loginValidator;
        }

        public async Task<BaseResponseModel> Login(LoginModel model)
        {
            ValidationResult resultValid = await _loginValidator.ValidateAsync(model);
            if (!resultValid.IsValid)
            {
                return new BaseResponseModel
                {
                    Message = resultValid.Errors.Select(x => x.ErrorMessage).ToList(),
                    Success = false
                };
            }

            var result = await _userRepository.Login(model);
            return result;
        }

        public async Task<BaseResponseModel> Register(RegisterModel model)
        {
            ValidationResult resultValid = await _registerValidator.ValidateAsync(model);
            if (!resultValid.IsValid)
            {
                return new BaseResponseModel
                {
                    Message = resultValid.Errors.Select(x => x.ErrorMessage).ToList(),
                    Success = false
                };
            }
            var result = await _userRepository.Register(model);
            return result;
        }
    }
}
