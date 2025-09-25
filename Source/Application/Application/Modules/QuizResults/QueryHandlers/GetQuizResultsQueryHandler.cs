using Application.Contracts.Modules.QuizResults.Dtos;
using Application.Contracts.Modules.QuizResults.Interfaces;
using Application.Contracts.Modules.QuizResults.Queries;
using Common.Application.Contracts.ReadModel;
using Common.Application.CQRS;

namespace Application.Modules.QuizResults.QueryHandlers;

public class GetQuizResultsQueryHandler(IQuizResultsReadModel readModel)
    : IQueryHandler<GetQuizResultsQuery, PaginatedListDto<QuizResultsListItemDto>>
{
    public Task<PaginatedListDto<QuizResultsListItemDto>>
        Handle(GetQuizResultsQuery query, CancellationToken cancellationToken) =>
        readModel.Get(query, cancellationToken);
}