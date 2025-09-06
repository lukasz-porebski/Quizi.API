using Application.Contracts.Modules.Quizzes.Dtos;
using Application.Contracts.Modules.Quizzes.Interfaces;
using Application.Contracts.Modules.Quizzes.Queries;
using Common.Application.Contracts.ReadModel;
using Common.Application.CQRS;

namespace Application.Modules.Quizzes.QueryHandlers;

public class GetQuizzesQueryHandler(IQuizzesReadModel readModel)
    : IQueryHandler<GetQuizzesQuery, PaginatedListDto<QuizzesListItemDto>>
{
    public Task<PaginatedListDto<QuizzesListItemDto>> Handle(GetQuizzesQuery query, CancellationToken cancellationToken) =>
        readModel.Get(query, cancellationToken);
}