using Domain.Modules.Quizzes.Constants;
using Domain.Modules.Quizzes.Data.Specifications.Sub;
using LP.Common.Domain.Specification;

namespace Domain.Modules.Quizzes.Specifications.Questions.OrdinalNumber;

internal class QuizQuestionMaxOrdinalNumberIsEqualToQuestionsCountSpecification
    : ISpecification<IReadOnlyCollection<QuizQuestionSpecificationData>>
{
    public string FailureMessageCode => QuizMessageCodes.QuestionMaxOrdinalNumberHasToBeQuestionsCount;

    public bool IsValid(IReadOnlyCollection<QuizQuestionSpecificationData> data) =>
        data.Max(q => q.OrdinalNumber).Equals(data.Count);
}