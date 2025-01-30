namespace Domain.Modules.Quizzes.Data.Specifications.Questions;

public record QuizQuestionSpecificationData(
    int OrderNumber,
    string Text,
    IReadOnlyCollection<string> Answers
) : QuizQuestionBaseSpecificationData(OrderNumber, Text);