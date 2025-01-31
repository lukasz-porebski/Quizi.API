using Domain.Modules.Quizzes.Enums;
using Domain.Modules.Quizzes.Interfaces;

namespace Domain.Modules.Quizzes.Data.Specifications.Questions;

public record QuizClosedQuestionSpecificationData(
    QuizClosedQuestionType Type,
    string Text,
    IReadOnlyCollection<IQuizClosedQuestionAnswer> Answers
);