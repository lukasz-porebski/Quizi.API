using Common.Domain.ValueObjects;

namespace Domain.Modules.SharedQuizzes.Data;

public record SharedQuizRemoveUserSpecificationData(
    IReadOnlyCollection<AggregateId> CurrentUserIds,
    AggregateId IdOfUserToRemove
);