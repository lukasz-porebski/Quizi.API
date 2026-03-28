using Application.Contracts.Modules.Permissions.Interfaces;
using Domain.Modules.Permissions.Models;
using LP.Common.Application.Contracts.User;
using LP.Common.Infrastructure.Database.EF;
using LP.Common.Shared.Providers;

namespace Infrastructure.Database.Modules.Permissions;

public class PermissionRepository(
    AppDbContext context,
    IDateTimeProvider dateTimeProvider,
    IUserContextProvider userContextProvider
) : BaseRepository<Permission>(context, dateTimeProvider, userContextProvider), IPermissionRepository;