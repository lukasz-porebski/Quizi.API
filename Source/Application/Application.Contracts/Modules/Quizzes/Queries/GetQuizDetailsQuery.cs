using Application.Contracts.Modules.Quizzes.Dtos;
using LP.Common.Application.Contracts.CQRS;
using LP.Common.Domain.ValueObjects;

namespace Application.Contracts.Modules.Quizzes.Queries;

public record GetQuizDetailsQuery(AggregateId Id) : IQuery<QuizDetailsDto?>;