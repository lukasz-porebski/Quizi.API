using Common.Application.Contracts.Interfaces;
using Domain.Modules.Permissions.Models;

namespace Application.Contracts.Modules.Permissions.Interfaces;

public interface IPermissionRepository : IRepository<Permission>;