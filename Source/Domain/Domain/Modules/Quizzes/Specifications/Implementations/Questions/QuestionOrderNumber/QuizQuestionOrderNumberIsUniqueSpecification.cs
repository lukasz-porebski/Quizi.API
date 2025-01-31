using Common.Domain.Specification;
using Common.Shared.Extensions;
using Domain.Modules.Quizzes.Constants;
using Domain.Modules.Quizzes.Data.Specifications.Questions;

namespace Domain.Modules.Quizzes.Specifications.Implementations.Questions.QuestionOrderNumber;

internal class QuizQuestionOrderNumberIsUniqueSpecification : ISpecification<IReadOnlyCollection<QuizQuestionSpecificationData>>
{
    public string FailureMessageCode => QuizMessageCodes.QuestionOrderNumberIsUnique;

    public bool IsValid(IReadOnlyCollection<QuizQuestionSpecificationData> data) =>
        !data.Select(q => q.OrderNumber)
            .ContainsDuplicates();
}