using RealShop.Domain.Enums;
using Microsoft.AspNetCore.Http;

namespace RealShop.Services.DTOs.Products;
public class ProductForUpdateDto
{
    public string Name { get; set; }
    public string Description { get; set; }
    public decimal Price { get; set; }
    public CategoryEnum Categories { get; set; }
    public int Quantity { get; set; }
    public string Color  { get; set; }
    public IFormFile ImageUrl { get; set; }
}
