using Domain.Modules.Users.Data;
using Domain.Modules.Users.Interfaces;
using LP.Common.Domain.Entities;
using LP.Common.Shared.Utils;

namespace Domain.Modules.Users.Models;

public class User : BaseAggregateRoot
{
    private readonly List<UserRole> _roles = [];

    internal User(
        UserCreationData data,
        IUserSpecificationFactory specificationFactory,
        IHasher hasher)
        : base(data.Id)
    {
        specificationFactory.CreateForCreation(data).ValidateAndThrow();

        Email = data.Email;
        HashedPassword = hasher.Hash(data.Password);

        _roles = data.RoleIds
            .Select(roleId => new UserRole(Id, roleId))
            .ToList();
    }

    private User() : base(null!)
    {
    }

    public string Email { get; private set; } = null!;
    public string HashedPassword { get; private set; } = null!;

    public IReadOnlyList<UserRole> Roles => _roles;
}