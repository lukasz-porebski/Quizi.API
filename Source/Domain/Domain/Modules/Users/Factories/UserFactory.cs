using Common.Shared.Utils;
using Domain.Modules.Users.Data;
using Domain.Modules.Users.Interfaces;
using Domain.Modules.Users.Models;

namespace Domain.Modules.Users.Factories;

public class UserFactory(IUserSpecificationFactory specificationFactory, IHasher hasher) : IUserFactory
{
    public User Create(UserCreationData data) =>
        new(data, specificationFactory, hasher);
}