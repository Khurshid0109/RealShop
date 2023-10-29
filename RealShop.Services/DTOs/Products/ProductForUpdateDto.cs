
using Microsoft.AspNetCore.Http;

namespace RealShop.Services.DTOs.Products;
public class ProductForUpdateDto
{
    public long Id { get; set; }
    public string Name { get; set; }
    public string Description { get; set; }
    public decimal Price { get; set; }
    public int CategoryId { get; set; }
    public int Quantity { get; set; }
    public string Color  { get; set; }
    public IFormFile Image { get; set; }
}
