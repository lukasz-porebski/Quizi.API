using Application.Contracts.Modules.SharedQuizzes.Interfaces;
using Application.Modules.SharedQuizzes.Constants;
using Domain.Modules.SharedQuizzes.Models;
using LP.Common.Application.Extensions;
using LP.Common.Domain.ValueObjects;

namespace Application.Modules.SharedQuizzes.Extensions;

internal static class SharedQuizRepositoryExtensions
{
    public static Task<SharedQuiz> GetOrThrowAsync(
        this ISharedQuizRepository source, AggregateId quizId, CancellationToken cancellationToken) =>
        source.GetOrThrowAsync(s => s.Id == quizId, SharedQuizMessageCodes.SharedQuizNotFound, cancellationToken);

    public static Task ExistsOrThrowAsync(
        this ISharedQuizRepository source, AggregateId quizId, AggregateId userId, CancellationToken cancellationToken) =>
        source.ExistsOrThrowAsync(s =>
                s.Id == quizId && s.Users.Any(u => u.UserId == userId),
            SharedQuizMessageCodes.SharedQuizNotFound,
            cancellationToken);
}