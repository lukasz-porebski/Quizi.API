namespace Application.Contracts.Modules.QuizzesVerification.Data;

public record QuizToRunClosedQuestionData(
    int No,
    int OrdinalNumber,
    string Text,
    IReadOnlyCollection<QuizToRunClosedQuestionAnswerData> Answers
);