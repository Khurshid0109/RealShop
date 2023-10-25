using RealShop.Data.Data;
using RealShop.Domain.Entities;
using RealShop.Data.IRepositories;

namespace RealShop.Data.Repositories;

public class ProductRepository : Repository<Products>, IProductRepository
{
    public ProductRepository(DataContext context) : base(context)
    {
    }
}