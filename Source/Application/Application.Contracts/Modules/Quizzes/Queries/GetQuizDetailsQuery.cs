using Application.Contracts.Modules.Quizzes.Dtos;
using Common.Application.Contracts.CQRS;
using Common.Domain.ValueObjects;

namespace Application.Contracts.Modules.Quizzes.Queries;

public record GetQuizDetailsQuery(AggregateId Id) : IQuery<QuizDetailsDto>;