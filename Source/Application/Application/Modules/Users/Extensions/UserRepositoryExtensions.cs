using Application.Contracts.Modules.Users.Interfaces;
using Domain.Modules.Users.Models;
using LP.Common.Application.Extensions;
using LP.Common.Domain.ValueObjects;

namespace Application.Modules.Users.Extensions;

internal static class UserRepositoryExtensions
{
    public static Task<User> GetOrThrowAsync(this IUserRepository source, AggregateId id, CancellationToken cancellationToken) =>
        source.GetOrThrowAsync(id, UserMessageCodes.UserNotFound, cancellationToken);

    public static Task ExistsOrThrowAsync(this IUserRepository source, AggregateId id, CancellationToken cancellationToken) =>
        source.ExistsOrThrowAsync(id, UserMessageCodes.UserNotFound, cancellationToken);
}