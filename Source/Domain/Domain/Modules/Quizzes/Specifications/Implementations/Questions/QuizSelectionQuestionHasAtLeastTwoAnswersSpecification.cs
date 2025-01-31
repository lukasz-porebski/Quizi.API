using Common.Domain.Specification;
using Domain.Modules.Quizzes.Constants;
using Domain.Modules.Quizzes.Interfaces;

namespace Domain.Modules.Quizzes.Specifications.Implementations.Questions;

internal class QuizSelectionQuestionHasAtLeastTwoAnswersSpecification
    : ISpecification<IReadOnlyCollection<IQuizClosedQuestionAnswer>>
{
    public string FailureMessageCode => QuizMessageCodes.SelectionQuestionHasNotAtLeastTwoAnswers;

    public bool IsValid(IReadOnlyCollection<IQuizClosedQuestionAnswer> data) => data.Count >= 2;
}