using Common.Domain.Specification;
using Common.Shared.Extensions;
using Domain.Modules.Quizzes.Constants;
using Domain.Modules.Quizzes.Data.Models.Sub;

namespace Domain.Modules.Quizzes.Specifications.Questions.AnswerOrderNumber;

internal class QuizQuestionAnswerOrderNumberIsUniqueSpecification : ISpecification<QuizClosedQuestionCreateData>
{
    public string FailureMessageCode => QuizMessageCodes.QuestionAnswerOrderNumberIsUnique;

    public bool IsValid(QuizClosedQuestionCreateData data) =>
        !data.Answers
            .Select(q => q.OrderNumber)
            .ContainsDuplicates();
}