using Application.Contracts.Modules.Users.Interfaces;
using Common.Application.Contracts.User;
using Common.Infrastructure.Database.EF;
using Common.Shared.Providers;
using Domain.Modules.Users.Models;

namespace Infrastructure.Database.Modules.Users;

public class UserRepository(AppDbContext context, IDateTimeProvider dateTimeProvider, IUserContextProvider userContextProvider)
    : BaseRepository<User>(context, dateTimeProvider, userContextProvider), IUserRepository;