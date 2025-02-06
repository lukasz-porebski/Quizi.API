using Common.Domain.Specification;
using Domain.Modules.Quizzes.Constants;
using Domain.Modules.Quizzes.Data.Specifications.Sub;

namespace Domain.Modules.Quizzes.Specifications.Questions.OrdinalNumber;

internal class QuizQuestionMaxOrdinalNumberIsEqualToQuestionsCountSpecification
    : ISpecification<IReadOnlyCollection<QuizQuestionSpecificationData>>
{
    public string FailureMessageCode => QuizMessageCodes.QuestionMaximalOrdinalNumberIsEqualToQuestionsCount;

    public bool IsValid(IReadOnlyCollection<QuizQuestionSpecificationData> data) =>
        data.Max(q => q.OrdinalNumber).Equals(data.Count);
}