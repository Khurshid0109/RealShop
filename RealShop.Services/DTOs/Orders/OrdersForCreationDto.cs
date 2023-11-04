using System.ComponentModel.DataAnnotations;

namespace RealShop.Services.DTOs.Orders;
public class OrdersForCreationDto
{
    [Required]
    public long UserId { get; set; }
    public ICollection<OrderProductDto> orderItems { get; set; }
}
