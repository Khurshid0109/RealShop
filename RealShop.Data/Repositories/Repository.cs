using RealShop.Data.Data;
using RealShop.Domain.Commons;
using RealShop.Data.IRepositories;
using Microsoft.EntityFrameworkCore;

namespace RealShop.Data.Repositories;
public class Repository<TEntity> : IRepository<TEntity> where TEntity : Auditable
{
    private readonly DataContext _context;
    private readonly DbSet<TEntity> _dbSet;

    public Repository(DataContext context)
    {
        _context = context;
        _dbSet = _context.Set<TEntity>();
    }

    public async Task<bool> DeleteAsync(long id)
    {
        var result = await _dbSet.FirstOrDefaultAsync(res => res.Id == id);

        _dbSet.Remove(result);
        return true;
    }

    public async Task<TEntity> InsertAsync(TEntity entity)
    {
        var result = await _dbSet.AddAsync(entity);
        return result.Entity;
    }

    public async Task<bool> SavechangesAsync()
    {
        return await _context.SaveChangesAsync()>0;
    }

    public IQueryable<TEntity> SelectAll()
    {
        return  _dbSet;
    }

    public async Task<TEntity> SelectByIdAsync(long id)
    {
        var result = await _dbSet.FirstOrDefaultAsync(res => res.Id == id);
        return result;
    }

    public async Task<TEntity> UpdateAsync(TEntity entity)
    {
        var result = _dbSet.Update(entity);
        return result.Entity;
    }
}
