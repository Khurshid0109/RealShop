using RealShop.Services.DTOs.Users;

namespace RealShop.Services.Interfaces;
public interface IUserService
{
    public Task<IEnumerable<UserForResultDto>> RetriveAllAsync();
    public Task<UserForResultDto> RetriveByIdAsync(long? id);
    public Task<UserForResultDto> CreateAsync(UserForCreationDto? dto);
    public Task<UserForResultDto> UpdateAsync(UserForUpdateDto? dto);
    public Task<bool> DeleteAsync(long? id);

}