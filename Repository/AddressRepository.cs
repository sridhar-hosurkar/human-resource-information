using DomainModels;
using Microsoft.EntityFrameworkCore;

namespace Repository;

public class AddressRepository : GenericRepository<Address>, IGenericRepository<Address>
{
    public AddressRepository(DbContext dbContext) : base(dbContext)
    {
    }

}
