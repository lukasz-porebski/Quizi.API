using Domain.Modules.Permissions.Data;
using Domain.Modules.Permissions.Models;

namespace Domain.Modules.Permissions.Interfaces;

public interface IPermissionFactory
{
    Permission Create(PermissionCreationData data);
}