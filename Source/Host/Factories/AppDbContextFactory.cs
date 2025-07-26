using Infrastructure.Database;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;

namespace Host.Factories;

public class AppDbContextFactory : IDesignTimeDbContextFactory<AppDbContext>
{
    public AppDbContext CreateDbContext(string[] args)
    {
        var config = new ConfigurationBuilder()
            .SetBasePath(Directory.GetCurrentDirectory())
            .AddJsonFile("Configs/appsettings.Development.json")
            .Build();

        var connectionString = config.GetValue<string>("Database:ConnectionString");
        if (string.IsNullOrEmpty(connectionString))
            throw new InvalidOperationException("Cannot find connection string 'ConnectionString'.");

        var builder = new DbContextOptionsBuilder<AppDbContext>();
        builder.UseSqlServer(connectionString);
        return new AppDbContext(builder.Options);
    }
}