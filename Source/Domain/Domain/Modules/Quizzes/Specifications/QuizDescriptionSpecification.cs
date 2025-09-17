using Common.Domain.Specification;
using Domain.Modules.Quizzes.Constants;

namespace Domain.Modules.Quizzes.Specifications;

internal class QuizDescriptionSpecification : ISpecification<string?>
{
    public string FailureMessageCode => QuizMessageCodes.DescriptionLengthIsTooLong;

    public bool IsValid(string? data) =>
        (data?.Length ?? 0) <= QuizConstants.MaxDescriptionLength;
}