using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using ReproDistinct.DAL;

var configBuilder = new ConfigurationBuilder()
    .SetBasePath(Directory.GetCurrentDirectory())
    .AddJsonFile("settings.json");
IConfiguration configuration = configBuilder.Build();

var services = new ServiceCollection();
services.ConfigureDbConnection<ReproDbContext, ReproPass, ReproPassMission>(configuration);

var serviceProvider = services.BuildServiceProvider();

var contextFactory = serviceProvider.GetRequiredService<IDbContextFactory<ReproDbContext>>();
var context = await contextFactory.CreateDbContextAsync();

await context.Database.EnsureCreatedAsync();

try
{
    var query1 = context.Affaires
    .Select(a => a.PassId)
    .Distinct();

    Console.WriteLine(query1.ToQueryString());
}
catch (Exception ex)
{
    Console.WriteLine("woups");
    Console.WriteLine(ex.Message);
}
finally
{
    await context.Database.EnsureDeletedAsync();
}