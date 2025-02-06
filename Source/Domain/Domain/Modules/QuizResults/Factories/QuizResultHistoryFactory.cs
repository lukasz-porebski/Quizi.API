using Common.Domain.ValueObjects;
using Common.Shared.Attributes;
using Domain.Modules.QuizResults.Data;
using Domain.Modules.QuizResults.Interfaces;
using Domain.Modules.QuizResults.Models;

namespace Domain.Modules.QuizResults.Factories;

[Factory]
public class QuizResultHistoryFactory : IQuizResultHistoryFactory
{
    public QuizResult Create(AggregateId id, QuizResultCreateData data) =>
        new(id, data);
}