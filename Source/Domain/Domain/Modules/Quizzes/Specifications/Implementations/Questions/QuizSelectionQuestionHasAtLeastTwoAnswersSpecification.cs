using Common.Domain.Specification;
using Domain.Modules.Quizzes.ValueObjects;

namespace Domain.Modules.Quizzes.Specifications.Implementations.Questions;

internal class QuizSelectionQuestionHasAtLeastTwoAnswersSpecification : ISpecification<IEnumerable<QuizQuestionOrderedAnswer>>
{
    public string FailureMessageCode => QuizMessages.SelectionQuestionHasNotAtLeastTwoAnswers();

    public bool IsValid(IEnumerable<QuizQuestionOrderedAnswer> data) => data.Count() >= 2;
}