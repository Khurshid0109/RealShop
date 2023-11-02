
namespace RealShop.Services.DTOs.Orders;
public class OrdersForUpdateDto
{
    public long Id { get; set; }
    public int UserId { get; set; }
    public ICollection<OrderProductDto> OrderItems { get; set; }
}
