using Common.Domain.ValueObjects;

namespace Domain.Modules.QuizzesVerification.Data.Sub;

public record QuizQuestionVerificationResultData(
    EntityNo EntityNo,
    float ScoredPoints,
    float PointsPossibleToGet
);