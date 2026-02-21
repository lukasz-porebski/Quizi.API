using Application.Contracts.Modules.QuizzesVerification.Dtos;
using Application.Contracts.Modules.QuizzesVerification.Queries;
using Common.Domain.ValueObjects;

namespace Application.Contracts.Modules.QuizzesVerification.Interfaces;

public interface IQuizOpenQuestionsAnswerForVerificationReadModel
{
    Task<IReadOnlyCollection<QuizOpenQuestionAnswerForVerificationDto>> Get(
        GetQuizOpenQuestionsAnswerForVerificationQuery query, AggregateId userId, CancellationToken cancellationToken);
}