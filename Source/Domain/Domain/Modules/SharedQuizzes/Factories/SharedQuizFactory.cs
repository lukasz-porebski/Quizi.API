using Common.Domain.ValueObjects;
using Common.Shared.Attributes;
using Domain.Modules.SharedQuizzes.Interfaces;
using Domain.Modules.SharedQuizzes.Models;

namespace Domain.Modules.SharedQuizzes.Factories;

[Factory]
public class SharedQuizFactory(ISharedQuizSpecificationFactory specificationFactory) : ISharedQuizFactory
{
    public SharedQuiz Create(AggregateId id, AggregateId ownerId, AggregateId userId) =>
        new(id, ownerId, userId, specificationFactory);
}