using RealShop.Data.Data;
using RealShop.Domain.Entities;
using RealShop.Data.IRepositories;

namespace RealShop.Data.Repositories;
public class UserRepository : Repository<Users>, IUserRepository
{
    public UserRepository(DataContext context) : base(context)
    {
    }
}