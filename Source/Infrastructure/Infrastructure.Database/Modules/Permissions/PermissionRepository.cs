using Application.Contracts.Modules.Permissions.Interfaces;
using Common.Application.Contracts.User;
using Common.Infrastructure.Database.EF;
using Common.Shared.Providers;
using Domain.Modules.Permissions.Models;

namespace Infrastructure.Database.Modules.Permissions;

public class PermissionRepository(
    AppDbContext context,
    IDateTimeProvider dateTimeProvider,
    IUserContextProvider userContextProvider
) : BaseRepository<Permission>(context, dateTimeProvider, userContextProvider), IPermissionRepository;