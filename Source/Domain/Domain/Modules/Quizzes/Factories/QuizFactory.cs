using Common.Domain.ValueObjects;
using Common.Shared.Attributes;
using Domain.Modules.Quizzes.Data.Models;
using Domain.Modules.Quizzes.Interfaces;
using Domain.Modules.Quizzes.Models;

namespace Domain.Modules.Quizzes.Factories;

[Factory]
public class QuizFactory(IQuizSpecificationFactory specificationFactory) : IQuizFactory
{
    public Quiz Create(AggregateId id, QuizCreateData data) =>
        new(id, data, specificationFactory);
}