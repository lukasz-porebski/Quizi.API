using Common.Domain.Specification;
using Common.Shared.Extensions;
using Domain.Modules.Quizzes.Constants;
using Domain.Modules.Quizzes.Data.Models.Sub;

namespace Domain.Modules.Quizzes.Specifications.Questions.AnswerOrderNumber;

internal class QuizQuestionAnswerOrderNumberIsUniqueSpecification : ISpecification<QuizClosedQuestionPersistData>
{
    public string FailureMessageCode => QuizMessageCodes.QuestionAnswerOrderNumberIsUnique;

    public bool IsValid(QuizClosedQuestionPersistData data) =>
        !data.Answers
            .Select(q => q.Data.OrderNumber)
            .ContainsDuplicates();
}