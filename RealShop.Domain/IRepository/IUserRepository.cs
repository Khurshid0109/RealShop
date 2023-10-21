

namespace RealShop.Domain.IRepository
{
    public interface IUserRepository<Tentity>
    {
        public Task<IQueryable<Tentity>> GetAll();
        public Task<Tentity> GetByIdAsync(long? id);
        public Task<Tentity> CreateAsync(Tentity entity);
        public Task<Tentity> UpdateAsync(Tentity entity);
        public Task<bool> DeleteAsync(long? id);
    }
}
