using Domain.Modules.Quizzes.Constants;
using LP.Common.Domain.Specification;

namespace Domain.Modules.Quizzes.Specifications;

internal class QuizDurationSpecification : ISpecification<TimeSpan>
{
    public string FailureMessageCode => QuizMessageCodes.QuizDurationIsOutOfRange;

    public bool IsValid(TimeSpan data) =>
        data >= TimeSpan.FromMinutes(1) || data <= TimeSpan.FromHours(3);
}