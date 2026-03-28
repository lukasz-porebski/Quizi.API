using LP.Common.Domain.Entities;
using LP.Common.Domain.ValueObjects;

namespace Domain.Modules.Users.Models;

public class UserRole : BaseEntityCore
{
    internal UserRole(AggregateId id, AggregateId roleId) : base(id)
    {
        RoleId = roleId;
    }

    private UserRole()
    {
    }

    public AggregateId RoleId { get; private set; } = null!;
}