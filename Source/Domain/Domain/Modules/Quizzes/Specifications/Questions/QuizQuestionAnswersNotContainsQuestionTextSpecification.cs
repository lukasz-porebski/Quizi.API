using Common.Domain.Specification;
using Domain.Modules.Quizzes.Constants;
using Domain.Modules.Quizzes.Data.Specifications.Sub;

namespace Domain.Modules.Quizzes.Specifications.Questions;

internal class QuizQuestionAnswersNotContainsQuestionTextSpecification : ISpecification<QuizQuestionSpecificationData>
{
    public string FailureMessageCode => QuizMessageCodes.AnswersContainsQuestionText;

    public bool IsValid(QuizQuestionSpecificationData data) =>
        !data.Answers.Select(a => a).Contains(data.Text);
}