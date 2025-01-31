using Common.Domain.Specification;
using Common.Shared.Extensions;
using Domain.Modules.Quizzes.Constants;
using Domain.Modules.Quizzes.Data.Specifications.Questions;

namespace Domain.Modules.Quizzes.Specifications.Implementations.Questions;

internal class QuizQuestionAnswersAreUniqueSpecification : ISpecification<QuizClosedEndedQuestionSpecificationData>
{
    public string FailureMessageCode => QuizMessageCodes.NonUniqueQuestionAnswers;

    public bool IsValid(QuizClosedEndedQuestionSpecificationData data) =>
        !data.Answers.ContainsDuplicates();
}