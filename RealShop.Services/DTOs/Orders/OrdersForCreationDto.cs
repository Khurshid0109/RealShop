using RealShop.Services.DTOs.OrderItems;

namespace RealShop.Services.DTOs.Orders;
public class OrdersForCreationDto
{
    public int UserId { get; set; }
    public ICollection<OrderItemsForCreation> OrderItems { get; set; }
}
