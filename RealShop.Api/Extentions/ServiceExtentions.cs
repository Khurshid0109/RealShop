using RealShop.Data.IRepositories;
using RealShop.Data.Repositories;
using RealShop.Services.Interfaces;
using RealShop.Services.Services;

namespace RealShop.Api.Extentions;
public static class ServiceExtentions
{
    public static void CustomExtention(this IServiceCollection collection)
    {
        collection.AddScoped<IUserService, UserService>();
        collection.AddScoped(typeof(IRepository<>), typeof(Repository<>));
    }
}

