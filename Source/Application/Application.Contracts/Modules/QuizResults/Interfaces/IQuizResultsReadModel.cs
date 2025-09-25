using Application.Contracts.Modules.QuizResults.Dtos;
using Application.Contracts.Modules.QuizResults.Queries;
using Common.Application.Contracts.ReadModel;

namespace Application.Contracts.Modules.QuizResults.Interfaces;

public interface IQuizResultsReadModel
{
    Task<PaginatedListDto<QuizResultsListItemDto>> Get(GetQuizResultsQuery query, CancellationToken cancellationToken);
}