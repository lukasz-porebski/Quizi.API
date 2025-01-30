using Common.Domain.Specification;
using Domain.Modules.Quizzes.Specifications.Data.Questions;

namespace Domain.Modules.Quizzes.Specifications.Implementations.Questions.QuestionAnswerOrderNumber;

internal class QuizQuestionAnswerMaximalOrderNumberIsEqualToQuestionsCountSpecification
    : ISpecification<QuizClosedEndedQuestionSpecificationData>
{
    public string FailureMessageCode => QuizMessages.QuestionAnswerMaximalOrderNumberIsEqualToQuestionsCount();

    public bool IsValid(QuizClosedEndedQuestionSpecificationData data) =>
        data.Answers.Max(q => q.OrderNumber).Equals(data.Answers.Count());
}