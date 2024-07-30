using Core.Business.BusinessManager.CategoryBusinessManager;
using Core.Business.BusinessManager.OrderBusinessManager;
using Core.Business.BusinessManager.ProductBusinessManager;
using Core.Business.BusinessManager.UserBusinessManager;
using Core.Business.BusinessRules;
using Core.Business.Results;
using FluentValidation;
using Microsoft.Extensions.DependencyInjection;
using System.Reflection;


namespace Core.Business
{
    public static class BusinessServiceRegistration
    {
        public static IServiceCollection AddBusinessServices(this IServiceCollection services)
        {
            services.AddAutoMapper(Assembly.GetExecutingAssembly());
            services.AddValidatorsFromAssembly(Assembly.GetExecutingAssembly());
        
            services.AddScoped<UserBusinessRules>();
            services.AddScoped<ProductBusinessRules>();
            services.AddScoped<CategoryBusinessRules>();
            services.AddScoped<OrderBusinessRules>();

            services.AddScoped<IUserManager, UserManager>();
            services.AddScoped<IProductManager, ProductManager>();
            services.AddScoped<ICategoryManager, CategoryManager>();
            services.AddScoped<IOrderManager, OrderManager>();
            services.AddScoped<IManager, Manager>();

            return services;
        }
    }
}
