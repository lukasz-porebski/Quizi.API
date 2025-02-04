using Common.Domain.ValueObjects;

namespace Domain.Modules.SharedQuizzes.Data;

public record SharedQuizAddUserSpecificationData(IReadOnlyCollection<AggregateId> CurrentUsers, AggregateId NewUserId);