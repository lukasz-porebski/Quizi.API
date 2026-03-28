using Domain.Modules.Users.Data;
using Domain.Modules.Users.Interfaces;
using Domain.Modules.Users.Models;
using LP.Common.Shared.Attributes;
using LP.Common.Shared.Utils;

namespace Domain.Modules.Users.Factories;

[Factory]
public class UserFactory(IUserSpecificationFactory specificationFactory, IHasher hasher) : IUserFactory
{
    public User Create(UserCreationData data) =>
        new(data, specificationFactory, hasher);
}