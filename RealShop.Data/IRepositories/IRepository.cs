
namespace RealShop.Data.IRepositories;

public interface IRepository<TEntity>
{
    public IQueryable<TEntity> SelectAll();
    public Task<TEntity> SelectByIdAsync(long? id);
    public Task<TEntity> InsertAsync(TEntity? entity);
    public Task<TEntity> UpdateAsync(TEntity? entity);
    public Task<bool> DeleteAsync(long? id);
    public Task<bool> SavechangesAsync();
}

