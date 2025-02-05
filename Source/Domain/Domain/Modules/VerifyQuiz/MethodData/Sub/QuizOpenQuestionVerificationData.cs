using Common.Domain.ValueObjects;

namespace Domain.Modules.VerifyQuiz.MethodData.Sub;

public record QuizOpenQuestionVerificationData(EntityNo No, bool? IsCorrect);