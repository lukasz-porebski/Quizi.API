using Common.Domain.Specification;
using Domain.Modules.Quizzes.Data.Specifications.Questions;

namespace Domain.Modules.Quizzes.Specifications.Implementations.Questions.QuestionAnswerOrderNumber;

internal class QuizQuestionAnswerMinimalOrderNumberIsOneSpecification
    : ISpecification<QuizClosedEndedQuestionSpecificationData>
{
    public string FailureMessageCode => QuizMessages.QuestionAnswerMinimalOrderNumberIsNotOne();

    public bool IsValid(QuizClosedEndedQuestionSpecificationData data) =>
        data.Answers.Min(q => q.OrderNumber).Equals(1);
}