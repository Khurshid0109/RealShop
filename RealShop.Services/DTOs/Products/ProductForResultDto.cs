
using RealShop.Domain.Enums;

namespace RealShop.Services.DTOs.Products;
public class ProductForResultDto
{
    public long Id { get; set; }
    public string Name { get; set; }
    public string Description { get; set; }
    public CategoryEnum Categories { get; set; }
    public decimal Price { get; set; }
    public int Quantity { get; set; }
    public string ImageUrl { get; set; }
}
