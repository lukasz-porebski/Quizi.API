using Application.Contracts.Modules.QuizResults.Dtos;
using Application.Contracts.Modules.QuizResults.Interfaces;
using Application.Contracts.Modules.QuizResults.Queries;
using LP.Common.Application.Contracts.User;
using LP.Common.Application.CQRS;

namespace Application.Modules.QuizResults.QueryHandlers;

public class GetQuizResultDetailsQueryHandler(IQuizResultDetailsReadModel readModel, IUserContextProvider userContextProvider)
    : IQueryHandler<GetQuizResultDetailsQuery, QuizResultDetailsDto?>
{
    public Task<QuizResultDetailsDto?> Handle(GetQuizResultDetailsQuery query, CancellationToken cancellationToken) =>
        readModel.Get(query, userContextProvider.GetOrThrow().UserId, cancellationToken);
}