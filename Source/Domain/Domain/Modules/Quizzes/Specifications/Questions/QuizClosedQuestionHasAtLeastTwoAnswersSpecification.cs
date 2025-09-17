using Common.Domain.Specification;
using Domain.Modules.Quizzes.Constants;
using Domain.Modules.Quizzes.Data.Models.Sub;

namespace Domain.Modules.Quizzes.Specifications.Questions;

internal class QuizClosedQuestionHasAtLeastTwoAnswersSpecification
    : ISpecification<IReadOnlyCollection<QuizClosedQuestionAnswerPersistData>>
{
    public string FailureMessageCode => QuizMessageCodes.ClosedQuestionHasToHasAtLeastTwoAnswers;

    public bool IsValid(IReadOnlyCollection<QuizClosedQuestionAnswerPersistData> data) =>
        data.Count >= 2;
}