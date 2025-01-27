using Common.Domain.Specification;
using Common.Shared.Attributes;
using Domain.Modules.Users.Data;
using Domain.Modules.Users.Interfaces;
using Domain.Modules.Users.Specifications;

namespace Domain.Modules.Users.Factories;

[Factory]
internal class UserSpecificationFactory : IUserSpecificationFactory
{
    public SpecificationBuilderDirector CreateForCreation(UserCreationData data) =>
        new SpecificationBuilderDirector.SpecificationBuilder<UserCreationData>(data)
            .And(new EmailFormatSpecification())
            .And(new PasswordFormatSpecification())
            .Build();
}