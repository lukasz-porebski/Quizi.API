using Domain.Modules.Quizzes.Interfaces;

namespace Domain.Modules.Quizzes.Data.Specifications.Questions;

public record QuizSingleChoiceQuestionSpecificationData(
    int OrderNumber,
    string Text,
    IReadOnlyCollection<IQuizClosedQuestionAnswer> Answers
) : IQuizQuestionBaseSpecificationData;