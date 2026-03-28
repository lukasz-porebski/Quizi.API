using Application.Contracts.Modules.Roles.Interfaces;
using Domain.Modules.Roles.Models;
using LP.Common.Application.Contracts.User;
using LP.Common.Infrastructure.Database.EF;
using LP.Common.Shared.Providers;

namespace Infrastructure.Database.Modules.Roles;

public class RoleRepository(AppDbContext context, IDateTimeProvider dateTimeProvider, IUserContextProvider userContextProvider)
    : BaseRepository<Role>(context, dateTimeProvider, userContextProvider), IRoleRepository;