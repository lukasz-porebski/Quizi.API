using Application.Contracts.Modules.QuizzesVerification.Data;
using LP.Common.Application.Contracts.CQRS;
using LP.Common.Domain.ValueObjects;

namespace Application.Contracts.Modules.QuizzesVerification.Queries;

public record GetQuizToRunQuery(AggregateId Id) : IQuery<QuizToRunData?>;