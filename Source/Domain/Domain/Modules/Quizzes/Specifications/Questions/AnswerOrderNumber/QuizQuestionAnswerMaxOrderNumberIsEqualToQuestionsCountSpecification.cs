using Common.Domain.Specification;
using Domain.Modules.Quizzes.Constants;
using Domain.Modules.Quizzes.Data.Models.Sub;

namespace Domain.Modules.Quizzes.Specifications.Questions.AnswerOrderNumber;

internal class QuizQuestionAnswerMaxOrderNumberIsEqualToQuestionsCountSpecification
    : ISpecification<QuizClosedQuestionCreateData>
{
    public string FailureMessageCode => QuizMessageCodes.QuestionAnswerMaximalOrderNumberIsEqualToQuestionsCount;

    public bool IsValid(QuizClosedQuestionCreateData data) =>
        data.Answers.Max(q => q.OrderNumber).Equals(data.Answers.Count);
}