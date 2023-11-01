
namespace RealShop.Services.DTOs.Orders;
public class OrdersForCreationDto
{
    public long UserId { get; set; }
    public ICollection<OrderProductDto> orderItems { get; set; }
}
