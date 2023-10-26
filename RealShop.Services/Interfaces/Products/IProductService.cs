using RealShop.Services.DTOs.Products;

namespace RealShop.Services.Interfaces.Products;
public interface IProductService
{
    public Task<bool> DeleteAsync(long id);
    public Task<ProductForResultDto> RetriveByIdAsync(long id);
    public Task<IEnumerable<ProductForResultDto>> RetriveAllAsync();
    public Task<ProductForResultDto> ModifyAsync(long id,ProductForUpdateDto dto);
    public Task<ProductForResultDto> CreateAsync(ProductForCreationDto dto);
}