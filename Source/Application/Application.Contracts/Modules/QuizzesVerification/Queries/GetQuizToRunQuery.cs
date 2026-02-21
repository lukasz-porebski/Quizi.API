using Application.Contracts.Modules.QuizzesVerification.Data;
using Common.Application.Contracts.CQRS;
using Common.Domain.ValueObjects;

namespace Application.Contracts.Modules.QuizzesVerification.Queries;

public record GetQuizToRunQuery(AggregateId Id) : IQuery<QuizToRunData?>;