using RealShop.Services.DTOs.Users;

namespace RealShop.Services.Interfaces.Users;
public interface IAuthService
{
    Task<LoginResultDto> AuthenticateAsync(LoginDto dto);
}
