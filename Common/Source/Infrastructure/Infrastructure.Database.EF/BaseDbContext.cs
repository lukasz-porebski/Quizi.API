using System.Reflection;
using Common.Identity.EF.Extensions;
using Microsoft.EntityFrameworkCore;

namespace Common.Infrastructure.Database.EF;

public abstract class BaseDbContext(DbContextOptions options, Assembly efProjectAssembly) : DbContext(options)
{
    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);
        modelBuilder.ApplyConfigurationsFromAssembly(efProjectAssembly);
        modelBuilder.AddIdentity();
    }
}