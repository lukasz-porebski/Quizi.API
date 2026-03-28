using Application.Contracts.Modules.QuizzesVerification.Dtos;
using LP.Common.Application.Contracts.CQRS;
using LP.Common.Domain.ValueObjects;

namespace Application.Contracts.Modules.QuizzesVerification.Queries;

public record GetQuizOpenQuestionsAnswerForVerificationQuery(AggregateId Id)
    : IQuery<IReadOnlyCollection<QuizOpenQuestionAnswerForVerificationDto>>;