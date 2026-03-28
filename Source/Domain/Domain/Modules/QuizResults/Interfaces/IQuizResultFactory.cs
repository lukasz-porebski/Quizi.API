using Domain.Modules.QuizResults.Data;
using Domain.Modules.QuizResults.Models;
using LP.Common.Domain.ValueObjects;

namespace Domain.Modules.QuizResults.Interfaces;

public interface IQuizResultFactory
{
    QuizResult Create(AggregateId id, QuizResultCreateData data);
}