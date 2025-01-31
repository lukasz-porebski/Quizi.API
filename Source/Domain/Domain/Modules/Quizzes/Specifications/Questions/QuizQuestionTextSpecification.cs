using Common.Domain.Specification;
using Domain.Modules.Quizzes.Constants;

namespace Domain.Modules.Quizzes.Specifications.Questions;

internal class QuizQuestionTextSpecification : ISpecification<string>
{
    public string FailureMessageCode => QuizMessageCodes.QuestionTextIsNotDefined;

    public bool IsValid(string data) =>
        data.Any();
}