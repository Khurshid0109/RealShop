
using RealShop.Services.DTOs.Users;

namespace RealShop.Services.DTOs.Orders;

public class OrdersForResultDto
{
    public int Id { get; set; }
    //public int UserId { get; set; }
    public UserForResultDto User { get; set; }
    public ICollection<OrderProductDto> orderItems { get; set; }
}