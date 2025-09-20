using Application.Contracts.Modules.QuizzesVerification.Queries;
using PublishedLanguage.Modules.QuizzesVerification.Responses;

namespace Application.Contracts.Modules.QuizzesVerification.Interfaces;

public interface IQuizOpenQuestionsAnswerForVerificationReadModel
{
    Task<IReadOnlyCollection<QuizOpenQuestionAnswerForVerificationResponse>> Get(
        GetQuizOpenQuestionsAnswerForVerificationQuery query, CancellationToken cancellationToken);
}