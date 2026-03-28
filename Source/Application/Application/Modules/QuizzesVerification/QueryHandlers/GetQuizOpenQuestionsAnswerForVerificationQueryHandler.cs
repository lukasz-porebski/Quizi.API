using Application.Contracts.Modules.QuizzesVerification.Dtos;
using Application.Contracts.Modules.QuizzesVerification.Interfaces;
using Application.Contracts.Modules.QuizzesVerification.Queries;
using LP.Common.Application.Contracts.User;
using LP.Common.Application.CQRS;

namespace Application.Modules.QuizzesVerification.QueryHandlers;

public class GetQuizOpenQuestionsAnswerForVerificationQueryHandler(
    IQuizOpenQuestionsAnswerForVerificationReadModel readModel,
    IUserContextProvider userContextProvider)
    : IQueryHandler<
        GetQuizOpenQuestionsAnswerForVerificationQuery,
        IReadOnlyCollection<QuizOpenQuestionAnswerForVerificationDto>>
{
    public Task<IReadOnlyCollection<QuizOpenQuestionAnswerForVerificationDto>> Handle(
        GetQuizOpenQuestionsAnswerForVerificationQuery query, CancellationToken cancellationToken) =>
        readModel.Get(query, userContextProvider.GetOrThrow().UserId, cancellationToken);
}