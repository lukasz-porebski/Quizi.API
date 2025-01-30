using Common.Domain.Specification;
using Common.Shared.Extensions;
using Domain.Modules.Quizzes.Specifications.Data.Questions;

namespace Domain.Modules.Quizzes.Specifications.Implementations.Questions.QuestionAnswerOrderNumber;

internal class QuizQuestionAnswerOrderNumberIsUniqueSpecification : ISpecification<QuizClosedEndedQuestionSpecificationData>
{
    public string FailureMessageCode => QuizMessages.QuestionAnswerOrderNumberIsUnique();

    public bool IsValid(QuizClosedEndedQuestionSpecificationData data) =>
        !data.Answers
            .Select(q => q.OrderNumber)
            .ContainsDuplicates();
}