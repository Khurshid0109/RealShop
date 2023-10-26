using AutoMapper;
using RealShop.Domain.Entities;
using RealShop.Services.DTOs.Users;
using RealShop.Services.DTOs.Products;

namespace RealShop.Services.Mappers;
public class MapperProfile:Profile
{
    public MapperProfile()
    {
        //mapping for Users
        CreateMap<Users, UserForUpdateDto>().ReverseMap();
        CreateMap<Users, UserForResultDto>().ReverseMap();
        CreateMap<Users,UserForCreationDto>().ReverseMap();

        //mapping for Products
        CreateMap<Product,ProductForCreationDto>().ReverseMap();
        CreateMap<Product,ProductForResultDto>().ReverseMap();
        CreateMap<Product,ProductForUpdateDto>().ReverseMap();


    }
}