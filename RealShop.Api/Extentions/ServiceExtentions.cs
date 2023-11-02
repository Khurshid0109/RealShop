using RealShop.Data.Repositories;
using RealShop.Services.Services;
using RealShop.Data.IRepositories;
using RealShop.Services.Interfaces;
using RealShop.Services.Services.Orders;
using RealShop.Services.Services.Products;
using RealShop.Services.Interfaces.Orders;
using RealShop.Services.Interfaces.Products;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.IdentityModel.Tokens;
using System.Text;
using RealShop.Services.Interfaces.Users;
using RealShop.Services.Services.Users;
using Microsoft.OpenApi.Models;
using System.Reflection;

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


        service.AddScoped<IAuthService,UserAuthService>();
        service.AddScoped(typeof(IRepository<>), typeof(Repository<>));
        
    }
    public static void AddJwtService(this IServiceCollection services, IConfiguration configuration)
    {
        services.AddAuthentication(options =>
        {
            options.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
            options.DefaultScheme = JwtBearerDefaults.AuthenticationScheme;
            options.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
        }).AddJwtBearer(options =>
        {
            options.TokenValidationParameters = new TokenValidationParameters
            {
                ValidateIssuer = true,
                ValidateAudience = false,
                ValidateLifetime = true,
                ValidateIssuerSigningKey = true,
                ValidIssuer = configuration["Jwt:Issuer"],
                ValidAudience = configuration["JWT:Audience"],
                IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(configuration["Jwt:Key"])),
                ClockSkew = TimeSpan.Zero
            };
        });
    }

    public static void AddSwaggerService(this IServiceCollection services)
    {
        services.AddSwaggerGen(c =>
        {
            c.SwaggerDoc("v1", new OpenApiInfo { Title = "Shamsheer.Api", Version = "v1" });
            var xmlFilename = $"{Assembly.GetExecutingAssembly().GetName().Name}.xml";

            c.AddSecurityDefinition("Bearer", new OpenApiSecurityScheme
            {
                Name = "Authorization",
                Description =
                    "JWT Authorization header using the Bearer scheme. Example: \"Authorization: Bearer {token}\"",
                In = ParameterLocation.Header,
                Type = SecuritySchemeType.ApiKey
            });

            c.AddSecurityRequirement(new OpenApiSecurityRequirement
        {
            {
                new OpenApiSecurityScheme
                {
                    Reference = new OpenApiReference
                    {
                        Type = ReferenceType.SecurityScheme,
                        Id = "Bearer"
                    }
                },
                new string[]{ }
            }
        });
        });
    }
}