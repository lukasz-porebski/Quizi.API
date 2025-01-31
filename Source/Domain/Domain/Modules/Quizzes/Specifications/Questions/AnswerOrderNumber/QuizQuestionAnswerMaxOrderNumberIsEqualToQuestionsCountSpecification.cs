using Common.Domain.Specification;
using Domain.Modules.Quizzes.Constants;
using Domain.Modules.Quizzes.Data.Specifications.Questions;

namespace Domain.Modules.Quizzes.Specifications.Questions.AnswerOrderNumber;

internal class QuizQuestionAnswerMaxOrderNumberIsEqualToQuestionsCountSpecification
    : ISpecification<QuizClosedQuestionSpecificationData>
{
    public string FailureMessageCode => QuizMessageCodes.QuestionAnswerMaximalOrderNumberIsEqualToQuestionsCount;

    public bool IsValid(QuizClosedQuestionSpecificationData data) =>
        data.Answers.Max(q => q.OrderNumber).Equals(data.Answers.Count);
}