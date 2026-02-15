using Application.Contracts.Modules.Roles.Interfaces;
using Common.Application.Contracts.User;
using Common.Infrastructure.Database.EF;
using Common.Shared.Providers;
using Domain.Modules.Roles.Models;

namespace Infrastructure.Database.Modules.Roles;

public class RoleRepository(AppDbContext context, IDateTimeProvider dateTimeProvider, IUserContextProvider userContextProvider)
    : BaseRepository<Role>(context, dateTimeProvider, userContextProvider), IRoleRepository;