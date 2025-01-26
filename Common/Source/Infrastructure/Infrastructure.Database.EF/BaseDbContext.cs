using Microsoft.EntityFrameworkCore;

namespace Common.Infrastructure.Database.EF;

public abstract class BaseDbContext(DbContextOptions options) : DbContext(options);