using Domain.Modules.Roles.Data;
using Domain.Modules.Roles.Models;

namespace Domain.Modules.Roles.Interfaces;

public interface IRoleFactory
{
    Role Create(RoleCreationData data);
}