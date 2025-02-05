using Domain.Modules.QuizzesVerification.Data.Sub;

namespace Domain.Modules.QuizzesVerification.Data;

public record QuizVerificationResultData(
    IReadOnlyCollection<QuizQuestionVerificationResultData> OpenQuestions,
    IReadOnlyCollection<QuizQuestionVerificationResultData> SingleChoiceQuestions,
    IReadOnlyCollection<QuizQuestionVerificationResultData> MultipleChoiceQuestions
);