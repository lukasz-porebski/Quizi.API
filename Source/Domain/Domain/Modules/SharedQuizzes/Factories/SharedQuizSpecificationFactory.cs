using Common.Domain.Specification;
using Common.Shared.Attributes;
using Domain.Modules.SharedQuizzes.Data;
using Domain.Modules.SharedQuizzes.Interfaces;
using Domain.Modules.SharedQuizzes.Specifications;

namespace Domain.Modules.SharedQuizzes.Factories;

[Factory]
public class SharedQuizSpecificationFactory : ISharedQuizSpecificationFactory
{
    public SpecificationBuilderDirector AddUser(SharedQuizAddUserSpecificationData data) =>
        new SpecificationBuilderDirector.SpecificationBuilder<SharedQuizAddUserSpecificationData>(data)
            .And(new SharedQuizAddUserSpecification())
            .Build();

    public SpecificationBuilderDirector RemoveUser(SharedQuizRemoveUserSpecificationData data) =>
        new SpecificationBuilderDirector.SpecificationBuilder<SharedQuizRemoveUserSpecificationData>(data)
            .And(new SharedQuizRemoveUserSpecification())
            .Build();
}