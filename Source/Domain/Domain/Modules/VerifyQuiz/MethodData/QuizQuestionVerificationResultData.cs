using Common.Domain.ValueObjects;

namespace Domain.Modules.VerifyQuiz.MethodData;

public record QuizQuestionVerificationResultData(
    EntityNo EntityNo,
    float ScoredPoints,
    float PointsPossibleToGet
);