using Common.Domain.ValueObjects;

namespace Domain.Modules.QuizzesVerification.Data.Sub;

public record QuizOpenQuestionVerificationData(EntityNo No, bool? IsCorrect);