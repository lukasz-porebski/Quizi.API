using Common.Domain.ValueObjects;

namespace Domain.Modules.QuizzesVerification.Data.Sub;

public record QuizMultipleChoiceQuestionVerificationData(
    EntityNo No,
    IReadOnlyCollection<EntityNo> SelectedAnswerNos
);