using Common.Domain.Specification;
using Common.Shared.Extensions;
using Domain.Modules.Quizzes.Constants;
using Domain.Modules.Quizzes.Data.Models.Sub;

namespace Domain.Modules.Quizzes.Specifications.Questions.AnswerOrdinalNumber;

internal class QuizQuestionAnswerOrdinalNumberIsUniqueSpecification : ISpecification<QuizClosedQuestionCreateData>
{
    public string FailureMessageCode => QuizMessageCodes.QuestionAnswerOrdinalNumberHasToBeUnique;

    public bool IsValid(QuizClosedQuestionCreateData data) =>
        !data.Answers
            .Select(q => q.OrdinalNumber)
            .ContainsDuplicates();
}