using Domain.Modules.SharedQuizzes.Models;
using LP.Common.Domain.ValueObjects;

namespace Domain.Modules.SharedQuizzes.Interfaces;

public interface ISharedQuizFactory
{
    SharedQuiz Create(AggregateId id, AggregateId quizId, AggregateId userId);
}