using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using RealShop.Services.DTOs.Users;
using RealShop.Services.Exceptions;
using RealShop.Services.Interfaces;
using RealShop.Services.Interfaces.Users;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace RealShop.Services.Services.Users;
public class UserAuthService : IAuthService
{
    private readonly IUserService _userService;
    private readonly IConfiguration _configuration;

    public UserAuthService(IUserService userService)
    {
        _userService = userService;
    }

    public async Task<LoginResultDto> AuthenticateAsync(LoginDto login)
    {
        var user = await _userService.RetriveByEmailAsync(login.Email);

        if (user is null) // Do logic for cheking password
            throw new CustomException(404, "User is not found!");

        //if (!BCrypt.Net.BCrypt.Verify(login.Password, user.HashedPassword))
         //   throw new CustomException(400, "Email or Password is incorrect");

        return new LoginResultDto
        {
            Token = GenerateToken(user)
        };
    }
    private string GenerateToken(UserForResultDto user)
    {
        var tokenHandler = new JwtSecurityTokenHandler();
        var tokenKey = Encoding.UTF8.GetBytes(_configuration["JWT:Key"]);
        var tokenDescriptor = new SecurityTokenDescriptor
        {
            Subject = new ClaimsIdentity(new Claim[]
            {
                 new Claim("Id", user.Id.ToString()),
                 new Claim(ClaimTypes.Name, user.FirstName),
                 new Claim(ClaimTypes.Email, user.Email)
                 // To Do  : Role logic 

            }),
            Audience = _configuration["JWT:Audience"],
            Issuer = _configuration["JWT:Issuer"],
            IssuedAt = DateTime.UtcNow,
            Expires = DateTime.UtcNow.AddMinutes(double.Parse(_configuration["JWT:Expire"])),
            SigningCredentials = new SigningCredentials(
                new SymmetricSecurityKey(tokenKey), SecurityAlgorithms.HmacSha256Signature)
        };

        var token = tokenHandler.CreateToken(tokenDescriptor);
        return tokenHandler.WriteToken(token);
    }
}
