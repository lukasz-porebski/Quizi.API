using Common.Domain.ValueObjects;
using Domain.Modules.QuizResults.Data;
using Domain.Modules.QuizResults.Models;

namespace Domain.Modules.QuizResults.Interfaces;

public interface IQuizResultHistoryFactory
{
    QuizResult Create(AggregateId id, QuizResultCreateData data);
}