using Domain.Modules.Permissions.Models;
using LP.Common.Application.Contracts.Interfaces;

namespace Application.Contracts.Modules.Permissions.Interfaces;

public interface IPermissionRepository : IRepository<Permission>;