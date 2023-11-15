using DomainModels;
using Microsoft.EntityFrameworkCore;

namespace Repository;

public class UserRepository : GenericRepository<User>, IGenericRepository<User>
{
    public UserRepository(DbContext dbContext) : base(dbContext)
    {
    }

}
