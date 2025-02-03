using Common.Domain.Specification;
using Domain.Modules.Quizzes.Constants;
using Domain.Modules.Quizzes.Data.Models.Sub;

namespace Domain.Modules.Quizzes.Specifications.Questions;

internal class QuizSelectionQuestionHasAtLeastTwoAnswersSpecification
    : ISpecification<IReadOnlyCollection<QuizClosedQuestionAnswerPersistData>>
{
    public string FailureMessageCode => QuizMessageCodes.SelectionQuestionHasNotAtLeastTwoAnswers;

    public bool IsValid(IReadOnlyCollection<QuizClosedQuestionAnswerPersistData> data) =>
        data.Count >= 2;
}