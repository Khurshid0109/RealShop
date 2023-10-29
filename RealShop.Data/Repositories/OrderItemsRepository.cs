using RealShop.Data.Data;
using RealShop.Domain.Entities;
using RealShop.Data.IRepositories;

namespace RealShop.Data.Repositories;
public class OrderItemsRepository : Repository<OrderItem>, IOrderItemsRepository
{
    public OrderItemsRepository(DataContext context) : base(context)
    {
    }
}