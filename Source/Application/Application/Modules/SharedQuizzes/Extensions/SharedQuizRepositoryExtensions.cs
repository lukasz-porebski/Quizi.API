using Application.Contracts.Modules.SharedQuizzes.Interfaces;
using Application.Modules.SharedQuizzes.Constants;
using Common.Application.Extensions;
using Common.Domain.ValueObjects;
using Domain.Modules.SharedQuizzes.Models;

namespace Application.Modules.SharedQuizzes.Extensions;

internal static class SharedQuizRepositoryExtensions
{
    public static Task<SharedQuiz> GetOrThrowAsync(
        this ISharedQuizRepository source, AggregateId quizId, CancellationToken cancellationToken) =>
        source.GetOrThrowAsync(s => s.Id == quizId, SharedQuizMessageCodes.SharedQuizNotFound, cancellationToken);
}