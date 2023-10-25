using RealShop.Data.Data;
using RealShop.Domain.Entities;
using RealShop.Data.IRepositories;

namespace RealShop.Data.Repositories;
public class OrdersRepository : Repository<Orders>, IOrderRepository
{
    public OrdersRepository(DataContext context) : base(context)
    {
    }
}