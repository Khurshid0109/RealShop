using RealShop.Data.Repositories;
using RealShop.Services.Services;
using RealShop.Data.IRepositories;
using RealShop.Services.Interfaces;

namespace RealShop.Api.Extentions;
public static class ServiceExtentions
{
    public static void CustomExtention(this IServiceCollection service)
    {
        service.AddScoped<IUserService, UserService>();
        service.AddScoped<IOrderRepository, OrdersRepository>();
        service.AddScoped<IProductRepository, ProductRepository>();
        service.AddScoped<IUserRepository, UserRepository>();
        service.AddScoped<ICategoryRepository, CategoryRepository>();
        service.AddScoped(typeof(IRepository<>), typeof(Repository<>));
        service.AddScoped<IOrderItemsRepository, OrderItemsRepository>();
    }
}