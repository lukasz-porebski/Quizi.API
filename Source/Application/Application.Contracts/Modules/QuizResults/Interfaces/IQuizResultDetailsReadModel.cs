using Application.Contracts.Modules.QuizResults.Dtos;
using Application.Contracts.Modules.QuizResults.Queries;
using Common.Domain.ValueObjects;

namespace Application.Contracts.Modules.QuizResults.Interfaces;

public interface IQuizResultDetailsReadModel
{
    Task<QuizResultDetailsDto?> Get(GetQuizResultDetailsQuery query, AggregateId userId, CancellationToken cancellationToken);
}