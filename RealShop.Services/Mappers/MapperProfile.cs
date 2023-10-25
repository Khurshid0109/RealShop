using AutoMapper;
using RealShop.Domain.Entities;
using RealShop.Services.DTOs.Users;

namespace RealShop.Services.Mappers;
public class MapperProfile:Profile
{
    public MapperProfile()
    {
        CreateMap<Users, UserForUpdateDto>().ReverseMap();
        CreateMap<Users, UserForResultDto>().ReverseMap();
        CreateMap<Users,UserForCreationDto>().ReverseMap();
    }
}