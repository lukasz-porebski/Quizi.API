using Common.Domain.Specification;
using Common.Shared.Extensions;
using Domain.Modules.Quizzes.Constants;
using Domain.Modules.Quizzes.Data.Specifications.Sub;

namespace Domain.Modules.Quizzes.Specifications.Questions.OrdinalNumber;

internal class QuizQuestionOrdinalNumberIsUniqueSpecification : ISpecification<IReadOnlyCollection<QuizQuestionSpecificationData>>
{
    public string FailureMessageCode => QuizMessageCodes.QuestionOrdinalNumberHasToBeUnique;

    public bool IsValid(IReadOnlyCollection<QuizQuestionSpecificationData> data) =>
        !data.Select(q => q.OrdinalNumber)
            .ContainsDuplicates();
}