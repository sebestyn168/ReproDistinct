using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using ReproDistinct.Configuration;
using ReproDistinct.DAL;

namespace Microsoft.Extensions.DependencyInjection;

public static class DbConnectionConfiguration
{
    public static IServiceCollection ConfigureDbConnection<Db, P, PM>(
        this IServiceCollection services,
        IConfiguration configuration)
        where Db : ReproDbContextBase<P, PM>
        where P : Pass<P, PM>
        where PM : Link_Pass_Mission<P, PM>
    {
        var connectionName = "DefaultConnection";
        var connectionString = configuration.GetConnectionString(connectionName);

        services
            .AddDbContext<Db>(options => options.UseSqlServer(connectionString), ServiceLifetime.Transient, ServiceLifetime.Transient)
            .AddDbContext<ReproDbContextBase<P, PM>, Db>(options => options.UseSqlServer(connectionString), ServiceLifetime.Transient, ServiceLifetime.Transient)
            .AddPooledDbContextFactory<Db>(options => options.UseSqlServer(connectionString))
            .AddSingleton<IDbContextFactory<ReproDbContextBase<P, PM>>, DbContextFactoryHelper<ReproDbContextBase<P, PM>, Db>>()
            ;

        return services;
    }
}