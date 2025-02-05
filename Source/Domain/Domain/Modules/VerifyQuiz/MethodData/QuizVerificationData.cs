using Common.Domain.ValueObjects;
using Domain.Modules.VerifyQuiz.MethodData.Sub;

namespace Domain.Modules.VerifyQuiz.MethodData;

public record QuizVerificationData(
    AggregateId QuizId,
    TimeSpan QuizCompletionTime,
    IReadOnlyCollection<QuizOpenQuestionVerificationData> OpenQuestions,
    IReadOnlyCollection<QuizSingleChoiceQuestionVerificationData> SingleChoiceQuestions,
    IReadOnlyCollection<QuizMultipleChoiceQuestionVerificationData> MultipleChoiceQuestions
);