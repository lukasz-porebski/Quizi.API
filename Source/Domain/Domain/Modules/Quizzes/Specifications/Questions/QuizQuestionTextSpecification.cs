using Common.Domain.Specification;
using Domain.Modules.Quizzes.Constants;

namespace Domain.Modules.Quizzes.Specifications.Questions;

internal class QuizQuestionTextSpecification : ISpecification<string>
{
    public string FailureMessageCode => QuizMessageCodes.IncorrectQuestionTextLength;

    public bool IsValid(string data) =>
        data.Length is >= 1 and <= QuizConstants.MaxQuestionTextLength;
}