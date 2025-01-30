using Common.Domain.Specification;
using Common.Shared.Extensions;
using Domain.Modules.Quizzes.Specifications.Data.Questions;

namespace Domain.Modules.Quizzes.Specifications.Implementations.Questions;

internal class QuizQuestionAnswersAreUniqueSpecification : ISpecification<QuizClosedEndedQuestionSpecificationData>
{
    public string FailureMessageCode => QuizMessages.NonUniqueQuestionAnswers();

    public bool IsValid(QuizClosedEndedQuestionSpecificationData data) =>
        !data.Answers.ContainsDuplicates();
}