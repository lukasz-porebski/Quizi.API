using Common.Infrastructure.Database.EF;

namespace Infrastructure.Database;

public class AppReadonlyDbContext(AppDbContext context) : BaseReadonlyDbContext<AppDbContext>(context);