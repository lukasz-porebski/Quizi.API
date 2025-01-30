using Common.Domain.Specification;
using Domain.Modules.Quizzes.Data.Specifications.Questions;

namespace Domain.Modules.Quizzes.Specifications.Implementations.Questions;

internal class QuizQuestionAnswersNotContainsQuestionTextSpecification : ISpecification<QuizQuestionSpecificationData>
{
    public string FailureMessageCode => QuizMessages.AnswersContainsQuestionText();

    public bool IsValid(QuizQuestionSpecificationData data) =>
        !data.Answers.Select(a => a).Contains(data.Text);
}