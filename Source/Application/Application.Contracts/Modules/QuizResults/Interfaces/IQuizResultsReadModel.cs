using Application.Contracts.Modules.QuizResults.Dtos;
using Application.Contracts.Modules.QuizResults.Queries;
using LP.Common.Application.Contracts.ReadModel;
using LP.Common.Domain.ValueObjects;

namespace Application.Contracts.Modules.QuizResults.Interfaces;

public interface IQuizResultsReadModel
{
    Task<PaginatedListDto<QuizResultsListItemDto>> Get(
        GetQuizResultsQuery query, AggregateId userId, CancellationToken cancellationToken);
}