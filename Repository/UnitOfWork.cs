using DomainModels;
using DomainModels.Context;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Storage;

namespace Repository;

public class UnitOfWork : IUnitOfWork, IDisposable
{
    // private UserRepository? _userRepository;
    // private AddressRepository? _addressRepository;
    private Dictionary<Type, object> _repositories;
    private HumanResourceContext _dbContext;
    private IDbContextTransaction _transaction;

    public UnitOfWork(HumanResourceContext dbContext)
    {
        _dbContext = dbContext;
        _transaction = _dbContext.Database.BeginTransaction();
        _repositories = new Dictionary<Type, object>();
    }

    // public UserRepository UserRepository
    // {
    //     get
    //     {
    //         if (_userRepository == null)
    //         {
    //             _userRepository = new UserRepository(_dbContext);
    //         }
    //         return _userRepository;
    //     }
    // }

    // public AddressRepository AddressRepository
    // {
    //     get
    //     {
    //         if (_addressRepository == null)
    //         {
    //             _addressRepository = new AddressRepository(_dbContext);
    //         }
    //         return _addressRepository;
    //     }
    // }

    public IGenericRepository<TEntity> GetRepository<TEntity>()
        where TEntity : BaseDomainModel
    {
        if (_repositories.ContainsKey(typeof(TEntity)))
        {
            return (IGenericRepository<TEntity>)_repositories[typeof(TEntity)];
        }

        var repository = new GenericRepository<TEntity>(_dbContext);
        _repositories.Add(typeof(TEntity), repository);
        return repository;
    }

    public async Task Commit()
    {
        await _transaction.CommitAsync();
    }

    public void Rollback()
    {
        // Rollback changes if needed
    }

    private bool disposed = false;

    protected virtual void Dispose(bool disposing)
    {
        if (!this.disposed)
        {
            if (disposing)
            {
                _dbContext.Dispose();
            }
        }
        this.disposed = true;
    }

    public void Dispose()
    {
        Dispose(true);
        GC.SuppressFinalize(this);
    }
}
