using Common.Domain.ValueObjects;
using Domain.Contracts.Modules.Users.Enums;

namespace Domain.Modules.Quizzes.Data;

public record QuizCreationData(
    AggregateId Id,
    string Email,
    string Password,
    UserRole Role
);