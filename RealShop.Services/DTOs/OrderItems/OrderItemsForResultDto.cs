
using RealShop.Services.DTOs.Products;

namespace RealShop.Services.DTOs.OrderItems;

public class OrderItemsForResultDto
{
    public int ProductId { get; set; }
    public ProductForCreationDto Product { get; set; }
    public int Quantity { get; set; }
}
