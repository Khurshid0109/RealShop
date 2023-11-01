using RealShop.Data.Repositories;
using RealShop.Services.Services;
using RealShop.Data.IRepositories;
using RealShop.Services.Interfaces;
using RealShop.Services.Services.Orders;
using RealShop.Services.Services.Products;
using RealShop.Services.Interfaces.Orders;
using RealShop.Services.Services.OrderItems;
using RealShop.Services.Interfaces.Products;
using RealShop.Services.Interfaces.OrderItems;

namespace RealShop.Api.Extentions;
public static class ServiceExtentions
{
    public static void CustomExtention(this IServiceCollection service)
    {
        service.AddScoped<IUserService, UserService>();
        service.AddScoped<IUserRepository, UserRepository>();

        service.AddScoped<IOrdersService,OrdersService>();
        service.AddScoped<IOrdersRepository, OrdersRepository>();

        service.AddScoped<IOrderItemsService,OrderItemsService>();
        service.AddScoped<IOrderItemsRepository, OrderItemsRepository>();

        service.AddScoped<IProductService,ProductsService>();
        service.AddScoped<IProductRepository, ProductRepository>();

        
        service.AddScoped(typeof(IRepository<>), typeof(Repository<>));
        
    }
}