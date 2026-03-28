using Application.Contracts.Modules.Quizzes.Dtos;
using Application.Contracts.Modules.Quizzes.Interfaces;
using Application.Contracts.Modules.Quizzes.Queries;
using LP.Common.Application.Contracts.ReadModel;
using LP.Common.Application.Contracts.User;
using LP.Common.Application.CQRS;

namespace Application.Modules.Quizzes.QueryHandlers;

public class GetQuizzesQueryHandler(IQuizzesReadModel readModel, IUserContextProvider userContextProvider)
    : IQueryHandler<GetQuizzesQuery, PaginatedListDto<QuizzesListItemDto>>
{
    public Task<PaginatedListDto<QuizzesListItemDto>> Handle(GetQuizzesQuery query, CancellationToken cancellationToken) =>
        readModel.Get(query, userContextProvider.GetOrThrow().UserId, cancellationToken);
}