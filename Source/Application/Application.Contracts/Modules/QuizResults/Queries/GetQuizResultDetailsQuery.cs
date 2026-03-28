using Application.Contracts.Modules.QuizResults.Dtos;
using LP.Common.Application.Contracts.CQRS;
using LP.Common.Domain.ValueObjects;

namespace Application.Contracts.Modules.QuizResults.Queries;

public record GetQuizResultDetailsQuery(AggregateId Id) : IQuery<QuizResultDetailsDto?>;