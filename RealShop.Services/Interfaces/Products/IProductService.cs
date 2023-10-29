using Microsoft.AspNetCore.Http;
using RealShop.Services.DTOs.Products;

namespace RealShop.Services.Interfaces.Products;
public interface IProductService
{
    Task<bool> DeleteAsync(long id);
    Task<string> UploadFile(IFormFile file);
    Task<ProductForResultDto> RetriveByIdAsync(long id);
    Task<IEnumerable<ProductForResultDto>> RetriveAllAsync();
    Task<ProductForResultDto> CreateAsync(ProductForCreationDto dto);
    Task<ProductForResultDto> ModifyAsync(long id, ProductForUpdateDto dto);

}