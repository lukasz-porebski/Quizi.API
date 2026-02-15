using Common.Domain.Entities;

namespace Domain.Modules.Permissions.Models;

public class Permission : BaseAggregateRoot
{
    private Permission() : base(null!)
    {
    }

    public string Name { get; private set; } = null!;
}