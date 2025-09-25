using Application.Contracts.Modules.QuizzesVerification.Interfaces;
using Application.Contracts.Modules.QuizzesVerification.Queries;
using Common.Application.Contracts.User;
using Common.Application.CQRS;
using PublishedLanguage.Modules.QuizzesVerification.Responses;

namespace Application.Modules.QuizzesVerification.QueryHandlers;

public class GetQuizOpenQuestionsAnswerForVerificationQueryHandler(
    IQuizOpenQuestionsAnswerForVerificationReadModel readModel,
    IUserContextProvider userContextProvider)
    : IQueryHandler<
        GetQuizOpenQuestionsAnswerForVerificationQuery,
        IReadOnlyCollection<QuizOpenQuestionAnswerForVerificationResponse>>
{
    public Task<IReadOnlyCollection<QuizOpenQuestionAnswerForVerificationResponse>> Handle(
        GetQuizOpenQuestionsAnswerForVerificationQuery query, CancellationToken cancellationToken) =>
        readModel.Get(query, userContextProvider.GetOrThrow().UserId, cancellationToken);
}