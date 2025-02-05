using Common.Domain.ValueObjects;

namespace Domain.Modules.VerifyQuiz.MethodData.Sub;

public record QuizMultipleChoiceQuestionVerificationData(
    EntityNo No,
    IReadOnlyCollection<EntityNo> SelectedAnswerNos
);