namespace Domain.Modules.VerifyQuiz.MethodData;

public record QuizVerificationResultData(
    IEnumerable<QuizQuestionVerificationResultData> OpenQuestions,
    IEnumerable<QuizQuestionVerificationResultData> SingleChoiceQuestions,
    IEnumerable<QuizQuestionVerificationResultData> MultipleChoiceQuestions
);