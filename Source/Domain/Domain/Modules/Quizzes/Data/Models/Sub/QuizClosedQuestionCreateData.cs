namespace Domain.Modules.Quizzes.Data.Models.Sub;

public record QuizClosedQuestionCreateData(
    int OrdinalNumber,
    string Text,
    IReadOnlyCollection<QuizClosedQuestionAnswerPersistData> Answers
);