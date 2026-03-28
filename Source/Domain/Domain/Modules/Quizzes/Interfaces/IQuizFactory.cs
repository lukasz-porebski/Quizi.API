using Domain.Modules.Quizzes.Data.Models;
using Domain.Modules.Quizzes.Models;
using LP.Common.Domain.ValueObjects;

namespace Domain.Modules.Quizzes.Interfaces;

public interface IQuizFactory
{
    Quiz Create(AggregateId id, QuizCreateData data);
}