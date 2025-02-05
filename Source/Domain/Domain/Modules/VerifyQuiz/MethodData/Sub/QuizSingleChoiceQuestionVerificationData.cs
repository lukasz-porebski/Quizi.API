using Common.Domain.ValueObjects;

namespace Domain.Modules.VerifyQuiz.MethodData.Sub;

public record QuizSingleChoiceQuestionVerificationData(EntityNo No, EntityNo? SelectedAnswerNo);