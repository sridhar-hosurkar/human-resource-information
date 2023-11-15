using Microsoft.EntityFrameworkCore;

namespace DomainModels.Context;

public class HumanResourceContext : DbContext
{
    public DbSet<User> User { get; set; }
    public DbSet<Address> Address { get; set; }

    public HumanResourceContext(DbContextOptions<HumanResourceContext> options)
        : base(options)
    {
        Database.EnsureCreated();
    }

    protected override void OnModelCreating(ModelBuilder builder)
    {
        base.OnModelCreating(builder);
    }

    //  protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    // {
    //     optionsBuilder.UseNpgsql("Server=localhost;Port=5432;;Database=HumanResourcesDB;Username=postgres; Password=admin123;Integrated Security=true;Pooling=true");
    //     // Database.EnsureCreated();
    // }
}
