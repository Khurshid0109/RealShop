using AutoMapper;
using RealShop.Domain.Entities;
using RealShop.Data.IRepositories;
using Microsoft.EntityFrameworkCore;
using RealShop.Services.DTOs.Users;
using RealShop.Services.Exceptions;
using RealShop.Services.Interfaces;

namespace RealShop.Services.Services; 
public class UserService : IUserService
{
    private readonly IUserRepository _userRepository;
    private readonly IMapper _mapper;

    public UserService(IUserRepository userRepository, IMapper mapper)
    {
        _userRepository = userRepository;
        _mapper = mapper;
    }

    public async Task<UserForResultDto> CreateAsync(UserForCreationDto dto)
    {
        var user = await _userRepository.SelectAll()
            .Where(u => u.Email.ToLower() == dto.Email.ToLower())
            .FirstOrDefaultAsync();

        if (user is not null)
            throw new CustomException(404, "User already exists!");

        var mapped = _mapper.Map<User>(dto);
        mapped.CreatedAt = DateTime.Now;

        var result= await _userRepository.InsertAsync(mapped);
        await _userRepository.SavechangesAsync();

        return _mapper.Map<UserForResultDto>(result);
    }

    public async Task<bool> DeleteAsync(long id)
    {
        var user = await _userRepository.SelectByIdAsync(id);

        if (user is null)
            throw new CustomException(404, "User is not found!");

        await _userRepository.DeleteAsync(id);
        await _userRepository.SavechangesAsync();
        return true;
    }

    public async Task<IEnumerable<UserForResultDto>> RetriveAllAsync()
    {
        var users =  _userRepository.SelectAll();

        return _mapper.Map<IEnumerable<UserForResultDto>>(users);
    }

    public async Task<UserForResultDto> RetriveByIdAsync(long id)
    {
        var user = await _userRepository.SelectAll()
            .Where(u => u.Id == id)
            .FirstOrDefaultAsync();

        if (user is null)
            throw new CustomException(404, "User is not found!");

        return _mapper.Map<UserForResultDto>(user);
    }

    public async Task<UserForResultDto> ModifyAsync(long id,UserForUpdateDto dto)
    {
        var user = await _userRepository.SelectAll()
            .Where(u => u.Id == id)
            .FirstOrDefaultAsync();

        if (user is null)
            throw new CustomException(404, "User is not found!");

        var mapped = _mapper.Map(dto, user);
        user.UpdatedAt=DateTime.Now;

        await _userRepository.UpdateAsync(mapped);
        await _userRepository.SavechangesAsync();

        return _mapper.Map<UserForResultDto>(mapped);
    }

    public async Task<UserForResultDto> RetriveByEmailAsync(string email)
    {
        var user = await _userRepository.SelectAll()
            .Where(u => u.Email == email)
            .FirstOrDefaultAsync();

        if (user is null)
            throw new CustomException(404, "User is not found!");

        return _mapper.Map<UserForResultDto>(user);
    }
}