using System.Linq.Expressions;
using DomainModels;
using Microsoft.EntityFrameworkCore;

namespace Repository;

public class GenericRepository<TEntity> : IGenericRepository<TEntity>
    where TEntity : BaseDomainModel
{
    protected readonly DbContext _dbContext;
    protected readonly DbSet<TEntity> _table;

    public GenericRepository(DbContext dbContext)
    {
        _dbContext = dbContext;
        _table = _dbContext.Set<TEntity>();
    }

    public async Task<IQueryable<TEntity>> GetAll()
    {
        return _table.AsNoTracking();
    }

    public async Task<IQueryable<TEntity>> GetByFilter(Expression<Func<TEntity, bool>> filter)
    {
        return _table.AsNoTracking().Where(filter);
    }

    public async Task<TEntity?> GetById(int id)
    {
        return await _table.AsNoTracking().SingleOrDefaultAsync(e => e.Id == id);
    }

    public async Task<int> Create(TEntity entity)
    {
        await _table.AddAsync(entity);
        await _dbContext.SaveChangesAsync();
        return entity.Id;
    }

    public async Task<int> Update(int id, TEntity entity)
    {
        var _entity = await GetById(id);
        if (_entity != null)
        {
            _table.Attach(entity);
            _dbContext.Entry(entity).State = EntityState.Modified;
            await _dbContext.SaveChangesAsync();
            return entity.Id;
        }
        return 0;
    }

    public async Task<int> Delete(int id)
    {
        var entity = await GetById(id);
        if (entity != null)
        {
            _table.Remove(entity);
            await _dbContext.SaveChangesAsync();
            return id;
        }
        return 0;
    }
}
