using Application.Contracts.Modules.Users.Interfaces;
using Domain.Modules.Users.Models;
using LP.Common.Application.Contracts.User;
using LP.Common.Infrastructure.Database.EF;
using LP.Common.Shared.Providers;

namespace Infrastructure.Database.Modules.Users;

public class UserRepository(AppDbContext context, IDateTimeProvider dateTimeProvider, IUserContextProvider userContextProvider)
    : BaseRepository<User>(context, dateTimeProvider, userContextProvider), IUserRepository;