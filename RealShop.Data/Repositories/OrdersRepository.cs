using RealShop.Data.Data;
using RealShop.Domain.Entities;
using RealShop.Data.IRepositories;

namespace RealShop.Data.Repositories;
public class OrdersRepository : Repository<Order>, IOrdersRepository
{
    public OrdersRepository(DataContext context) : base(context)
    {
    }
}