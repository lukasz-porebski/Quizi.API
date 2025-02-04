namespace Domain.Modules.Quizzes.Data.Models.Sub;

public record QuizClosedQuestionCreateData(
    int OrderNumber,
    string Text,
    IReadOnlyCollection<QuizClosedQuestionAnswerPersistData> Answers
);