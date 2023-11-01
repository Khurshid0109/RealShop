using RealShop.Data.Repositories;
using RealShop.Services.Services;
using RealShop.Data.IRepositories;
using RealShop.Services.Interfaces;
using RealShop.Services.Services.Orders;
using RealShop.Services.Services.Products;
using RealShop.Services.Interfaces.Orders;
using RealShop.Services.Interfaces.Products;

namespace RealShop.Api.Extentions;
public static class ServiceExtentions
{
    public static void CustomExtention(this IServiceCollection service)
    {
        service.AddScoped<IUserService, UserService>();
        service.AddScoped<IUserRepository, UserRepository>();

        service.AddScoped<IOrdersService,OrdersService>();
        service.AddScoped<IOrdersRepository, OrdersRepository>();

        service.AddScoped<IProductService,ProductsService>();
        service.AddScoped<IProductRepository, ProductRepository>();

        
        service.AddScoped(typeof(IRepository<>), typeof(Repository<>));
        
    }
}