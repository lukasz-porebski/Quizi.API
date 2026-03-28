using Domain.Modules.Quizzes.Constants;
using LP.Common.Domain.Specification;

namespace Domain.Modules.Quizzes.Specifications.Questions;

internal class QuizQuestionAnswerTextSpecification : ISpecification<string>
{
    public string FailureMessageCode => QuizMessageCodes.IncorrectQuestionAnswerTextLength;

    public bool IsValid(string data) =>
        data.Length is >= 1 and <= QuizConstants.MaxQuestionTextLength;
}