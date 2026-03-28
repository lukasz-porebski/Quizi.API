using Domain.Modules.SharedQuizzes.Interfaces;
using Domain.Modules.SharedQuizzes.Models;
using LP.Common.Domain.ValueObjects;
using LP.Common.Shared.Attributes;

namespace Domain.Modules.SharedQuizzes.Factories;

[Factory]
public class SharedQuizFactory(ISharedQuizSpecificationFactory specificationFactory) : ISharedQuizFactory
{
    public SharedQuiz Create(AggregateId id, AggregateId quizId, AggregateId userId) =>
        new(id, quizId, userId, specificationFactory);
}