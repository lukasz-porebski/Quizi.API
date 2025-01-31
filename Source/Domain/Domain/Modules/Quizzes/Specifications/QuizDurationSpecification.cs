using Common.Domain.Specification;
using Domain.Modules.Quizzes.Constants;

namespace Domain.Modules.Quizzes.Specifications;

internal class QuizDurationSpecification : ISpecification<TimeSpan>
{
    public string FailureMessageCode => QuizMessageCodes.IncorrectQuizDuration;

    public bool IsValid(TimeSpan data) =>
        data >= TimeSpan.FromMinutes(1) || data <= TimeSpan.FromHours(3);
}