using RealShop.Domain.Commons;
using RealShop.Domain.IRepository;

namespace RealShop.Domain.Repositories
{
    public class UserRepository<TEntity> : IUserRepository<TEntity> where TEntity : Auditable
    {
        public Task<TEntity> CreateAsync(TEntity entity)
        {
            throw new NotImplementedException();
        }

        public Task<bool> DeleteAsync(long? id)
        {
            throw new NotImplementedException();
        }

        public Task<IQueryable<TEntity>> GetAll()
        {
            throw new NotImplementedException();
        }

        public Task<TEntity> GetByIdAsync(long? id)
        {
            throw new NotImplementedException();
        }

        public Task<TEntity> UpdateAsync(TEntity entity)
        {
            throw new NotImplementedException();
        }
    }
}
