using Common.Domain.Specification;
using Domain.Modules.Quizzes.Constants;
using Domain.Modules.Quizzes.ValueObjects;

namespace Domain.Modules.Quizzes.Specifications.Implementations.Questions;

internal class QuizSelectionQuestionHasAtLeastTwoAnswersSpecification : ISpecification<IReadOnlyCollection<QuizQuestionOrderedAnswer>>
{
    public string FailureMessageCode => QuizMessageCodes.SelectionQuestionHasNotAtLeastTwoAnswers;

    public bool IsValid(IReadOnlyCollection<QuizQuestionOrderedAnswer> data) => data.Count >= 2;
}