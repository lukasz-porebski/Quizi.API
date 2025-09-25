using Application.Contracts.Modules.Quizzes.Dtos;
using Application.Contracts.Modules.Quizzes.Queries;
using Common.Domain.ValueObjects;

namespace Application.Contracts.Modules.Quizzes.Interfaces;

public interface IQuizDetailsReadModel
{
    Task<QuizDetailsDto?> Get(GetQuizDetailsQuery query, AggregateId userId, CancellationToken cancellationToken);
}