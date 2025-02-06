namespace Domain.Modules.Quizzes.Data.Specifications.Sub;

public record QuizQuestionSpecificationData(
    int OrdinalNumber,
    string Text,
    IReadOnlyCollection<string> Answers
);