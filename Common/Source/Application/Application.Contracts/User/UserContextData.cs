using Common.Domain.ValueObjects;

namespace Common.Application.Contracts.User;

public record UserContextData(
    AggregateId UserId
);