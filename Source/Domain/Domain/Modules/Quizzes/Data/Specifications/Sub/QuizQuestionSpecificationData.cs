namespace Domain.Modules.Quizzes.Data.Specifications.Sub;

public record QuizQuestionSpecificationData(
    int OrderNumber,
    string Text,
    IReadOnlyCollection<string> Answers
);