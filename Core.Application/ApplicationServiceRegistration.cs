using Core.Application.Repositories.CategoryRepositories;
using Core.Application.Repositories.OperationClaimRepositories;
using Core.Application.Repositories.OrderDetailsRepositories;
using Core.Application.Repositories.OrderRepositories;
using Core.Application.Repositories.ProductRepositories;
using Core.Application.Repositories.UserOperationClaimRepositories;
using Core.Application.Repositories.UserRepositories;
using Core.Application.Services.AuthManager;
using Microsoft.Extensions.DependencyInjection;

namespace Core.Application
{
    public static class ApplicationServiceRegistration
    {
        public static IServiceCollection AddApplicationServices(this IServiceCollection services)
        {
            services.AddScoped<IUserRepository, UserRepository>();
            services.AddScoped<IOperationClaimRepository,OperationClaimRepository>();
            services.AddScoped<IUserOperationClaimRepository,UserOperationClaimRepository>();
            services.AddScoped<IAuthenticationManager, AuthenticationManager>();
            services.AddScoped<IProductRepository, ProductRepository>();
            services.AddScoped<ICategoryRepository, CategoryRepository>();
            services.AddScoped<IOrderRepository, OrderRepository>();
            services.AddScoped<IOrderDetailsRepository, OrderDetailsRepository>();

            return services;
        }
    }
}
