using AutoMapper;
using Microsoft.EntityFrameworkCore;
using RealShop.Data.IRepositories;
using RealShop.Domain.Entities;
using RealShop.Services.DTOs.Users;
using RealShop.Services.Exceptions;
using RealShop.Services.Interfaces;

namespace RealShop.Services.Services;
public class UserService : IUserService
{
    private readonly IMapper _mapper;
    private readonly IRepository<Users> _repository;
    public UserService(IMapper mapper,IRepository<Users> repository )
    {
        _mapper = mapper;
        _repository = repository;
    }
    public async Task<UserForResultDto> CreateAsync(UserForCreationDto? dto)
    {
        if (dto is null)
            throw new CustomException(400, "Argument is null here!");

        var user = await _repository.SelectAll().FirstOrDefaultAsync(u => u.Email == dto.Email);

        if (user is not null)
            throw new CustomException(409, "User with this email is already exist!");

        var mapped = _mapper.Map<Users>(dto);

        var result = await _repository.InsertAsync(mapped);
        await _repository.SavechangesAsync();
       
        return _mapper.Map<UserForResultDto>(result);
    }

    public async Task<bool> DeleteAsync(long? id)
    {
        if (id is null)
            throw new CustomException(400, "Argument is null here!");

        var user = await _repository.SelectByIdAsync(id);

        if (user is null)
            throw new CustomException(404, "User is not found!");

        await _repository.DeleteAsync(id);
        await _repository.SavechangesAsync();
        return true;
    }

    public async Task<IEnumerable<UserForResultDto>> RetriveAllAsync()
    {
        var user= _repository.SelectAll().ToList();
        var mapped = _mapper.Map<IEnumerable<UserForResultDto>>(user);

        return mapped;
    }

    public async Task<UserForResultDto> RetriveByIdAsync(long? id)
    {
        if (id is null)
            throw new CustomException(400, "Argument is null here!");

        var user = await _repository.SelectByIdAsync(id);

        if (user is null)
            throw new CustomException(404, "User is not found!");

        return _mapper.Map<UserForResultDto>(user);
    }

    public async Task<UserForResultDto> UpdateAsync(UserForUpdateDto? dto)
    {
        if (dto is null)
            throw new CustomException(404, "Argument is null here!");

        var user = await _repository.SelectByIdAsync(dto.Id);

        if (user is null)
            throw new CustomException(404, "User is not found!");

        var mapped = _mapper.Map<Users>(dto);
        var result=await _repository.UpdateAsync(mapped);
        await _repository.SavechangesAsync();

        return _mapper.Map<UserForResultDto>(result);
    }
}