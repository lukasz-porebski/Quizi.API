using Common.Infrastructure.Database.EF;
using Domain.Modules.Users.Models;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Database;

public class AppDbContext(DbContextOptions<AppDbContext> options)
    : BaseDbContext(options, typeof(AppDbContext).Assembly)
{
    public DbSet<User> Users { get; set; } = null!;
}