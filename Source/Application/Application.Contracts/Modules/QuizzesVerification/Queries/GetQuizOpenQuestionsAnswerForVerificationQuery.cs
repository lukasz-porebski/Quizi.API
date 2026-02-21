using Application.Contracts.Modules.QuizzesVerification.Dtos;
using Common.Application.Contracts.CQRS;
using Common.Domain.ValueObjects;

namespace Application.Contracts.Modules.QuizzesVerification.Queries;

public record GetQuizOpenQuestionsAnswerForVerificationQuery(AggregateId Id)
    : IQuery<IReadOnlyCollection<QuizOpenQuestionAnswerForVerificationDto>>;