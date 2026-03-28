using Domain.Modules.QuizResults.Data;
using Domain.Modules.QuizResults.Interfaces;
using Domain.Modules.QuizResults.Models;
using LP.Common.Domain.ValueObjects;
using LP.Common.Shared.Attributes;

namespace Domain.Modules.QuizResults.Factories;

[Factory]
public class QuizResultFactory : IQuizResultFactory
{
    public QuizResult Create(AggregateId id, QuizResultCreateData data) =>
        new(id, data);
}