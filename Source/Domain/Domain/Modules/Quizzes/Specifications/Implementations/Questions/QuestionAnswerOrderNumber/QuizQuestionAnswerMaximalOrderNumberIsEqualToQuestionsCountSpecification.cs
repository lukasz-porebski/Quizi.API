using Common.Domain.Specification;
using Domain.Modules.Quizzes.Constants;
using Domain.Modules.Quizzes.Data.Specifications.Questions;

namespace Domain.Modules.Quizzes.Specifications.Implementations.Questions.QuestionAnswerOrderNumber;

internal class QuizQuestionAnswerMaximalOrderNumberIsEqualToQuestionsCountSpecification
    : ISpecification<QuizClosedEndedQuestionSpecificationData>
{
    public string FailureMessageCode => QuizMessageCodes.QuestionAnswerMaximalOrderNumberIsEqualToQuestionsCount;

    public bool IsValid(QuizClosedEndedQuestionSpecificationData data) =>
        data.Answers.Max(q => q.OrderNumber).Equals(data.Answers.Count);
}