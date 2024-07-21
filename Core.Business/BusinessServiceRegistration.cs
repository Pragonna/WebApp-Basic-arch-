using Core.Business.BusinessManager.CategoryBusinessManager;
using Core.Business.BusinessManager.ProductBusinessManager;
using Core.Business.BusinessManager.UserBusinessManager;
using Core.Business.BusinessRules;
using Microsoft.Extensions.DependencyInjection;
using System.Reflection;


namespace Core.Business
{
    public static class BusinessServiceRegistration
    {
        public static IServiceCollection AddBusinessServices(this IServiceCollection services)
        {
            services.AddAutoMapper(Assembly.GetExecutingAssembly());

            services.AddScoped<UserBusinessRules>();
            services.AddScoped<ProductBusinessRules>();
            services.AddScoped<CategoryBusinessRules>();

            services.AddScoped<IUserManager, UserManager>();
            services.AddScoped<IProductManager, ProductManager>();
            services.AddScoped<ICategoryManager, CategoryManager>();

            return services;
        }
    }
}
