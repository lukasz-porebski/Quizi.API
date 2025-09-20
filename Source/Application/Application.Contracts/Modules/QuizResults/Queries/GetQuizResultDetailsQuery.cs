using Application.Contracts.Modules.QuizResults.Dtos;
using Common.Application.Contracts.CQRS;
using Common.Domain.ValueObjects;

namespace Application.Contracts.Modules.QuizResults.Queries;

public record GetQuizResultDetailsQuery(AggregateId Id) : IQuery<QuizResultDetailsDto>;