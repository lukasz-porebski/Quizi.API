using Common.Domain.Specification;
using Common.Shared.Extensions;
using Domain.Modules.Quizzes.Constants;
using Domain.Modules.Quizzes.Data.Specifications.Questions;

namespace Domain.Modules.Quizzes.Specifications.Implementations.Questions.QuestionAnswerOrderNumber;

internal class QuizQuestionAnswerOrderNumberIsUniqueSpecification : ISpecification<QuizClosedEndedQuestionSpecificationData>
{
    public string FailureMessageCode => QuizMessageCodes.QuestionAnswerOrderNumberIsUnique;

    public bool IsValid(QuizClosedEndedQuestionSpecificationData data) =>
        !data.Answers
            .Select(q => q.OrderNumber)
            .ContainsDuplicates();
}