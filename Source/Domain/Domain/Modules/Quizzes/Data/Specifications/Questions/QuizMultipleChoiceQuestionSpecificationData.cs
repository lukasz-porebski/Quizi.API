using Domain.Modules.Quizzes.Data.Questions.Create;
using Domain.Modules.Quizzes.Interfaces;

namespace Domain.Modules.Quizzes.Data.Specifications.Questions;

public record QuizMultipleChoiceQuestionSpecificationData(
    int OrderNumber,
    string Text,
    IReadOnlyCollection<IQuizClosedQuestionAnswer> Answers
) : IQuizQuestionBaseSpecificationData;