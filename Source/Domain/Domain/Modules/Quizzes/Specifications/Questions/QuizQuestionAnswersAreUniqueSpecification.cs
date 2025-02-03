using Common.Domain.Specification;
using Common.Shared.Extensions;
using Domain.Modules.Quizzes.Constants;
using Domain.Modules.Quizzes.Data.Models.Sub;

namespace Domain.Modules.Quizzes.Specifications.Questions;

internal class QuizQuestionAnswersAreUniqueSpecification : ISpecification<QuizClosedQuestionPersistData>
{
    public string FailureMessageCode => QuizMessageCodes.NonUniqueQuestionAnswers;

    public bool IsValid(QuizClosedQuestionPersistData data) =>
        !data.Answers.ContainsDuplicates();
}