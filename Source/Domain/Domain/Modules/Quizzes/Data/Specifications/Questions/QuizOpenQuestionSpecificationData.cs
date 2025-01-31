using Domain.Modules.Quizzes.Interfaces;

namespace Domain.Modules.Quizzes.Data.Specifications.Questions;

public record QuizOpenQuestionSpecificationData(
    int OrderNumber,
    string Text,
    string CorrectAnswer
) : IQuizQuestionBaseSpecificationData;
