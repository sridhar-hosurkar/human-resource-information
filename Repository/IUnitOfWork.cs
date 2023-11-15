using DomainModels;
using Microsoft.EntityFrameworkCore;

namespace Repository;

public interface IUnitOfWork : IDisposable
{
    Task Commit();
    void Rollback();
    IGenericRepository<TEntity> GetRepository<TEntity>() where TEntity : BaseDomainModel;
}