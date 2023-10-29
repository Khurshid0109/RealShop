using AutoMapper;
using RealShop.Domain.Entities;
using RealShop.Services.DTOs.Users;
using RealShop.Services.DTOs.Orders;
using RealShop.Services.DTOs.Products;
using RealShop.Services.DTOs.OrderItems;

namespace RealShop.Services.Mappers;
public class MapperProfile:Profile
{
    public MapperProfile()
    {
        //mapping for Users
        CreateMap<User, UserForUpdateDto>().ReverseMap();
        CreateMap<User, UserForResultDto>().ReverseMap();
        CreateMap<User,UserForCreationDto>().ReverseMap();

        //mapping for Products
        CreateMap<Product,ProductForCreationDto>().ReverseMap();
        CreateMap<Product,ProductForResultDto>().ReverseMap();
        CreateMap<Product,ProductForUpdateDto>().ReverseMap();

        //mapping for Orders
        CreateMap<Order,OrdersForCreationDto>().ReverseMap();
        CreateMap<Order, OrdersForResultDto>().ReverseMap();
        CreateMap<Order,OrdersForUpdateDto>().ReverseMap();

        //mapping for OrderItems
        CreateMap<OrderItem, OrderItemsForCreation>().ReverseMap();
        CreateMap<OrderItem,OrderItemsForResultDto>().ReverseMap();
        CreateMap<OrderItem, OrderItemsForUpdateDto>().ReverseMap();

    }
}