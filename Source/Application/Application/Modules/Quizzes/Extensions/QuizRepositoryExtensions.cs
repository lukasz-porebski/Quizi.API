using Application.Contracts.Modules.Quizzes.Interfaces;
using Application.Modules.Quizzes.Constants;
using Domain.Modules.Quizzes.Models;
using LP.Common.Application.Extensions;
using LP.Common.Domain.ValueObjects;

namespace Application.Modules.Quizzes.Extensions;

internal static class QuizRepositoryExtensions
{
    public static Task<Quiz> GetOrThrowAsync(this IQuizRepository source, AggregateId id, CancellationToken cancellationToken) =>
        source.GetOrThrowAsync(id, QuizMessageCodes.QuizNotFound, cancellationToken);

    public static Task<Quiz> GetOrThrowAsync(
        this IQuizRepository source, AggregateId id, AggregateId ownerId, CancellationToken cancellationToken) =>
        source.GetOrThrowAsync(s => s.Id == id && s.OwnerId == ownerId, QuizMessageCodes.QuizNotFound, cancellationToken);

    public static Task<Quiz> GetOrThrowAsync(this IQuizRepository source, Guid code, CancellationToken cancellationToken) =>
        source.GetOrThrowAsync(s => s.Code == code, QuizMessageCodes.QuizNotFound, cancellationToken);

    public static Task ExistsOrThrowAsync(
        this IQuizRepository source, AggregateId id, AggregateId ownerId, CancellationToken cancellationToken) =>
        source.ExistsOrThrowAsync(s => s.Id == id && s.OwnerId == ownerId, QuizMessageCodes.QuizNotFound, cancellationToken);
}