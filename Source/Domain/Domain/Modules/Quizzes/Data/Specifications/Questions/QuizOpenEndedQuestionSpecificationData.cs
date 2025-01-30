namespace Domain.Modules.Quizzes.Data.Specifications.Questions;

internal record QuizOpenEndedQuestionSpecificationData(
    int OrderNumber,
    string Text,
    string CorrectAnswer
) : QuizQuestionBaseSpecificationData(OrderNumber, Text);
