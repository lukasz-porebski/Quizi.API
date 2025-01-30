using Domain.Modules.Quizzes.Enums;
using Domain.Modules.Quizzes.ValueObjects;

namespace Domain.Modules.Quizzes.Data.Specifications.Questions;

public record QuizClosedEndedQuestionSpecificationData(
    QuizClosedEndedQuestionType Type,
    string Text,
    IReadOnlyCollection<QuizQuestionOrderedAnswer> Answers
);