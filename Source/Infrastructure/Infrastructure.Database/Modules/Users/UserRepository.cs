using Application.Contracts.Modules.Users.Interfaces;
using Common.Infrastructure.Database.EF;
using Common.Shared.Providers;
using Domain.Modules.Users.Models;

namespace Infrastructure.Database.Modules.Users;

public class UserRepository(AppDbContext context, IDateTimeProvider dateTimeProvider)
    : BaseRepository<User>(context, dateTimeProvider), IUserRepository;