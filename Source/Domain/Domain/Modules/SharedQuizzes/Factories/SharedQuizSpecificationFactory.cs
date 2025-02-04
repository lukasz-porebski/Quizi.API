using Common.Domain.Specification;
using Domain.Modules.SharedQuizzes.Data;
using Domain.Modules.SharedQuizzes.Interfaces;
using Domain.Modules.SharedQuizzes.Specifications;
using Domain.Shared.Specifications;

namespace Domain.Modules.SharedQuizzes.Factories;

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