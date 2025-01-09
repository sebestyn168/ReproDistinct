using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Diagnostics;
using Microsoft.Extensions.DependencyInjection;

namespace ReproDistinct.Configuration;

public static class ConfigurePooledDbContextExtensions
{
    public static IServiceCollection AddPooledDbContext<Db>(this IServiceCollection services, string connectionString)
        where Db : DbContext
        => services
            .AddDbContext<Db>(options =>
            {
                options.UseSqlServer(connectionString);
                options.ConfigureWarnings(w => w.Ignore(RelationalEventId.PendingModelChangesWarning));
            }, ServiceLifetime.Transient, ServiceLifetime.Transient)
            .AddPooledDbContextFactory<Db>(options =>
            {
                options.UseSqlServer(connectionString);
                options.ConfigureWarnings(w => w.Ignore(RelationalEventId.PendingModelChangesWarning));
            })
            ;

    public static IServiceCollection AddPooledDbContext<ContextBase, Db>(this IServiceCollection services, string connectionString)
        where Db : DbContext, ContextBase
        where ContextBase : DbContext
        => services
            .AddDbContext<Db>(options => options.UseSqlServer(connectionString), ServiceLifetime.Transient, ServiceLifetime.Transient)
            .AddDbContext<ContextBase, Db>(options =>
            {
                options.UseSqlServer(connectionString);
                options.ConfigureWarnings(w => w.Ignore(RelationalEventId.PendingModelChangesWarning));
            }, ServiceLifetime.Transient, ServiceLifetime.Transient)
            .AddPooledDbContextFactory<Db>(options =>
            {
                options.UseSqlServer(connectionString);
                options.ConfigureWarnings(w => w.Ignore(RelationalEventId.PendingModelChangesWarning));
            })
            .AddSingleton<IDbContextFactory<ContextBase>, DbContextFactoryHelper<ContextBase, Db>>()
            ;
}