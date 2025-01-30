using Common.Domain.Entities;
using Common.Shared.Utils;
using Domain.Contracts.Modules.Users.Enums;
using Domain.Modules.Users.Data;
using Domain.Modules.Users.Interfaces;

namespace Domain.Modules.Users.Models;

public class User : BaseAggregateRoot
{
    public User(
        UserCreationData data,
        IUserSpecificationFactory specificationFactory,
        IHasher hasher)
        : base(data.Id)
    {
        specificationFactory.CreateForCreation(data).ValidateAndThrow();

        Email = data.Email;
        Role = data.Role;
        HashedPassword = hasher.Hash(data.Password);
    }

    private User() : base(null!)
    {
    }

    public string Email { get; private set; } = null!;
    public UserRole Role { get; private set; }
    public string HashedPassword { get; private set; } = null!;
}