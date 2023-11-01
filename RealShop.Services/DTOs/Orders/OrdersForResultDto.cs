
namespace RealShop.Services.DTOs.Orders;

public class OrdersForResultDto
{
    public int OrderId { get; set; }
    public int UserId { get; set; }
    public ICollection<OrderProductDto> orderItems { get; set; }
}