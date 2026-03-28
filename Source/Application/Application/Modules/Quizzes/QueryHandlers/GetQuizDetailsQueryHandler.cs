using Application.Contracts.Modules.Quizzes.Dtos;
using Application.Contracts.Modules.Quizzes.Interfaces;
using Application.Contracts.Modules.Quizzes.Queries;
using LP.Common.Application.Contracts.User;
using LP.Common.Application.CQRS;

namespace Application.Modules.Quizzes.QueryHandlers;

public class GetQuizDetailsQueryHandler(IQuizDetailsReadModel readModel, IUserContextProvider userContextProvider)
    : IQueryHandler<GetQuizDetailsQuery, QuizDetailsDto?>
{
    public Task<QuizDetailsDto?> Handle(GetQuizDetailsQuery query, CancellationToken cancellationToken) =>
        readModel.Get(query, userContextProvider.GetOrThrow().UserId, cancellationToken);
}