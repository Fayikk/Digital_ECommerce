using Digital_Core_Layer.Services.Abstract;
using Digital_Core_Layer.Services.Concrete;
using Digital_Core_Layer.Validators;
using Digital_Domain_Layer.Entities;
using Digital_Persistence_Layer;
using FluentValidation;
using FluentValidation.AspNetCore;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace Digital_Core_Layer
{
    public static class ServiceRegistrations
    {
        public static void AddCoreRegisterServices(this IServiceCollection Services,IConfiguration Configuration = null)
        {
            Services.AddPersistenceServiceRegistration(Configuration);
            Services.AddScoped<IUserService, UserService>();
            Services.AddScoped<IMainCategoryService, MainCategoryService>();
            Services.AddScoped<ISubCategoryService, SubCategoryService>();
            Services.AddScoped<IProductService, ProductService>();
            Services.AddScoped<IProductImageService, ProductImageService>();
            Services.AddScoped<IShoppingCartService, ShoppingCartService>();
            Services.AddScoped<IOrderService, OrderService>();
            //Services.AddControllers().AddFluentValidation(cfg => cfg.RegisterValidatorsFromAssemblyContaining<LoginValidator>())
            //    .AddFluentValidation(cfg => cfg.RegisterValidatorsFromAssemblyContaining<RegisterValidator>());
            Services.AddValidatorsFromAssemblyContaining<LoginValidator>();
            Services.AddValidatorsFromAssemblyContaining<RegisterValidator>();
            Services.AddDbContext<Digital_Persistence_Layer.AppDbContext.ApplicationDbContext>(opt => opt.UseNpgsql(Configuration?.GetConnectionString("DefaultConnection")));
            Services.AddIdentity<User,IdentityRole>().AddEntityFrameworkStores<Digital_Persistence_Layer.AppDbContext.ApplicationDbContext>();
        }
    }
}
