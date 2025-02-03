using Common.Domain.Specification;
using Domain.Modules.Quizzes.Constants;
using Domain.Modules.Quizzes.Data.Models.Sub;

namespace Domain.Modules.Quizzes.Specifications.Questions.AnswerOrderNumber;

internal class QuizQuestionAnswerMinOrderNumberIsOneSpecification : ISpecification<QuizClosedQuestionPersistData>
{
    public string FailureMessageCode => QuizMessageCodes.QuestionAnswerMinimalOrderNumberIsNotOne;

    public bool IsValid(QuizClosedQuestionPersistData data) =>
        data.Answers.Min(q => q.Data.OrderNumber).Equals(1);
}