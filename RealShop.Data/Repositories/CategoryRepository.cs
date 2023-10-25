using RealShop.Data.Data;
using RealShop.Domain.Entities;
using RealShop.Data.IRepositories;

namespace RealShop.Data.Repositories;
public class CategoryRepository : Repository<Categories>, ICategoryRepository
{
    public CategoryRepository(DataContext context) : base(context)
    {
    }
}