using Domain.Modules.Quizzes.Constants;
using Domain.Modules.Quizzes.Data.Models.Sub;
using LP.Common.Domain.Specification;
using LP.Common.Shared.Extensions;

namespace Domain.Modules.Quizzes.Specifications.Questions;

internal class QuizQuestionAnswersAreUniqueSpecification : ISpecification<QuizClosedQuestionCreateData>
{
    public string FailureMessageCode => QuizMessageCodes.QuestionAnswersHaveToBeUnique;

    public bool IsValid(QuizClosedQuestionCreateData data) =>
        !data.Answers.ContainsDuplicates();
}