using Common.Domain.Specification;
using Domain.Modules.Quizzes.Constants;
using Domain.Modules.Quizzes.Data.Specifications.Questions;

namespace Domain.Modules.Quizzes.Specifications.Questions.OrderNumber;

internal class QuizQuestionMaxOrderNumberIsEqualToQuestionsCountSpecification
    : ISpecification<IReadOnlyCollection<QuizQuestionSpecificationData>>
{
    public string FailureMessageCode => QuizMessageCodes.QuestionMaximalOrderNumberIsEqualToQuestionsCount;

    public bool IsValid(IReadOnlyCollection<QuizQuestionSpecificationData> data) =>
        data.Max(q => q.OrderNumber).Equals(data.Count);
}