using Common.Domain.ValueObjects;
using Domain.Modules.SharedQuizzes.Models;

namespace Domain.Modules.SharedQuizzes.Interfaces;

public interface ISharedQuizFactory
{
    SharedQuiz Create(AggregateId id, AggregateId ownerId, AggregateId userId);
}