
using System.ComponentModel.DataAnnotations;

namespace RealShop.Services.DTOs.Orders;
public class OrdersForUpdateDto
{
    [Required]
    public long Id { get; set; }
    [Required]
    public int UserId { get; set; }
    public ICollection<OrderProductDto> OrderItems { get; set; }
}
