using Common.Domain.ValueObjects;

namespace Domain.Modules.QuizzesVerification.Data.Sub;

public record QuizSingleChoiceQuestionVerificationData(EntityNo No, EntityNo? SelectedAnswerNo);