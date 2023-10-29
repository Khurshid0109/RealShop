using RealShop.Services.DTOs.OrderItems;

namespace RealShop.Services.Interfaces.OrderItems;
public interface IOrderItemsService
{
    public Task<bool> DeleteAsync(long id);
    public Task<OrderItemsForResultDto> RetriveByIdAsync(long id);
    public Task<IEnumerable<OrderItemsForResultDto>> RetriveAllAsync();
    public Task<OrderItemsForResultDto> CreateAsync(OrderItemsForCreation dto);
    public Task<OrderItemsForResultDto> ModifyAsync(long id, OrderItemsForUpdateDto dto);
}
