using RealShop.Services.DTOs.Users;

namespace RealShop.Services.Interfaces;
public interface IProductService
{
    public Task<bool> DeleteAsync(long id);
    public Task<UserForResultDto> RetriveByIdAsync(long id);
    public Task<IEnumerable<UserForResultDto>> RetriveAllAsync();
    public Task<UserForResultDto> UpdateAsync(UserForUpdateDto dto);
    public Task<UserForResultDto> CreateAsync(UserForCreationDto dto);
}
