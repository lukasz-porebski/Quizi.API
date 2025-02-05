using Domain.Modules.Quizzes.Models;
using Domain.Modules.QuizzesVerification.Data.Sub;

namespace Domain.Modules.QuizzesVerification.Data;

public record QuizVerificationData(
    Quiz Quiz,
    IReadOnlyCollection<QuizOpenQuestionVerificationData> OpenQuestions,
    IReadOnlyCollection<QuizSingleChoiceQuestionVerificationData> SingleChoiceQuestions,
    IReadOnlyCollection<QuizMultipleChoiceQuestionVerificationData> MultipleChoiceQuestions
);