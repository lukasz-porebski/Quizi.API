using Common.Domain.Specification;
using Domain.Modules.Quizzes.Constants;
using Domain.Modules.Quizzes.Data.Models.Sub;

namespace Domain.Modules.Quizzes.Specifications.Questions.AnswerOrderNumber;

internal class QuizQuestionAnswerMinOrderNumberIsOneSpecification : ISpecification<QuizClosedQuestionCreateData>
{
    public string FailureMessageCode => QuizMessageCodes.QuestionAnswerMinimalOrderNumberIsNotOne;

    public bool IsValid(QuizClosedQuestionCreateData data) =>
        data.Answers.Min(q => q.OrderNumber).Equals(1);
}