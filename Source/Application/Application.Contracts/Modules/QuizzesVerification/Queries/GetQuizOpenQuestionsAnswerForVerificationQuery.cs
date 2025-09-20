using Common.Application.Contracts.CQRS;
using Common.Domain.ValueObjects;
using PublishedLanguage.Modules.QuizzesVerification.Responses;

namespace Application.Contracts.Modules.QuizzesVerification.Queries;

public record GetQuizOpenQuestionsAnswerForVerificationQuery(AggregateId Id)
    : IQuery<IReadOnlyCollection<QuizOpenQuestionAnswerForVerificationResponse>>;