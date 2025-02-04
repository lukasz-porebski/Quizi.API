using Common.Domain.Specification;
using Common.Shared.Extensions;
using Domain.Modules.Quizzes.Constants;
using Domain.Modules.Quizzes.Data.Models.Sub;

namespace Domain.Modules.Quizzes.Specifications.Questions;

internal class QuizQuestionAnswersAreUniqueSpecification : ISpecification<QuizClosedQuestionCreateData>
{
    public string FailureMessageCode => QuizMessageCodes.NonUniqueQuestionAnswers;

    public bool IsValid(QuizClosedQuestionCreateData data) =>
        !data.Answers.ContainsDuplicates();
}