using Common.Domain.Specification;
using Domain.Modules.Quizzes.Constants;
using Domain.Modules.Quizzes.Data.Specifications.Questions;

namespace Domain.Modules.Quizzes.Specifications.Implementations.Questions.QuestionAnswerOrderNumber;

internal class QuizQuestionAnswerMinimalOrderNumberIsOneSpecification
    : ISpecification<QuizClosedQuestionSpecificationData>
{
    public string FailureMessageCode => QuizMessageCodes.QuestionAnswerMinimalOrderNumberIsNotOne;

    public bool IsValid(QuizClosedQuestionSpecificationData data) =>
        data.Answers.Min(q => q.OrderNumber).Equals(1);
}