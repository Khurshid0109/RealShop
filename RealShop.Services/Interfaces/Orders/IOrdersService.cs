using RealShop.Services.DTOs.Orders;

namespace RealShop.Services.Interfaces.Orders;
public interface IOrdersService
{
    public Task<bool> DeleteAsync(long id);
    public Task<OrdersForResultDto> RetriveByIdAsync(long id);
    public Task<IEnumerable<OrdersForResultDto>> RetriveAllAsync();
    public Task<OrdersForResultDto> CreateAsync(OrdersForCreationDto dto);
    public Task<OrdersForResultDto> ModifyAsync(long id, OrdersForUpdateDto dto);
}
