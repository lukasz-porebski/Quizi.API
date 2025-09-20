using Application.Contracts.Modules.QuizzesVerification.Interfaces;
using Application.Contracts.Modules.QuizzesVerification.Queries;
using Common.Application.CQRS;
using PublishedLanguage.Modules.QuizzesVerification.Responses;

namespace Application.Modules.QuizzesVerification.QueryHandlers;

public class GetQuizOpenQuestionsAnswerForVerificationQueryHandler(IQuizOpenQuestionsAnswerForVerificationReadModel readModel)
    : IQueryHandler<
        GetQuizOpenQuestionsAnswerForVerificationQuery,
        IReadOnlyCollection<QuizOpenQuestionAnswerForVerificationResponse>>
{
    public Task<IReadOnlyCollection<QuizOpenQuestionAnswerForVerificationResponse>> Handle(
        GetQuizOpenQuestionsAnswerForVerificationQuery query, CancellationToken cancellationToken) =>
        readModel.Get(query, cancellationToken);
}