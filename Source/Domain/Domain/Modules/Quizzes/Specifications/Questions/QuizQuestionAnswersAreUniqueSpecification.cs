using Common.Domain.Specification;
using Common.Shared.Extensions;
using Domain.Modules.Quizzes.Constants;
using Domain.Modules.Quizzes.Data.Specifications.Questions;

namespace Domain.Modules.Quizzes.Specifications.Questions;

internal class QuizQuestionAnswersAreUniqueSpecification : ISpecification<QuizClosedQuestionSpecificationData>
{
    public string FailureMessageCode => QuizMessageCodes.NonUniqueQuestionAnswers;

    public bool IsValid(QuizClosedQuestionSpecificationData data) =>
        !data.Answers.ContainsDuplicates();
}