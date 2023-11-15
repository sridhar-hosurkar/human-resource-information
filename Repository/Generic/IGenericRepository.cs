using System.Linq.Expressions;
using DomainModels;

namespace Repository;

public interface IGenericRepository<TEntity>
    where TEntity : BaseDomainModel
{
    Task<IQueryable<TEntity>> GetAll();

    Task<TEntity?> GetById(int id);

    Task<IQueryable<TEntity>> GetByFilter(Expression<Func<TEntity, bool>> filter);

    Task<int> Create(TEntity entity);

    Task<int> Update(int id, TEntity entity);

    Task<int> Delete(int id);
}
