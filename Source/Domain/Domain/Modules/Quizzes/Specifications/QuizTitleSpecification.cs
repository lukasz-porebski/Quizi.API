using Domain.Modules.Quizzes.Constants;
using LP.Common.Domain.Specification;

namespace Domain.Modules.Quizzes.Specifications;

internal class QuizTitleSpecification : ISpecification<string>
{
    public string FailureMessageCode => QuizMessageCodes.IncorrectTitleLength;

    public bool IsValid(string data) =>
        data.Length is >= 5 and <= QuizConstants.MaxTitleLength;
}