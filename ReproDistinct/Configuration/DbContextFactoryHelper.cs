using Microsoft.EntityFrameworkCore;

namespace ReproDistinct.Configuration;

public class DbContextFactoryHelper<TBaseContext, TCurrent> : IDbContextFactory<TBaseContext>
    where TBaseContext : DbContext
    where TCurrent : TBaseContext
{
    private readonly IDbContextFactory<TCurrent> _factory;

    public DbContextFactoryHelper(IDbContextFactory<TCurrent> factory)
    {
        _factory = factory;
    }

    public TBaseContext CreateDbContext()
    {
        return _factory.CreateDbContext();
    }
}