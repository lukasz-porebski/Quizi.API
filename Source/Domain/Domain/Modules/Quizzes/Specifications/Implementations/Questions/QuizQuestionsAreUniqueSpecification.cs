using Common.Domain.Specification;
using Domain.Modules.Quizzes.Data.Specifications.Questions;
using Domain.Modules.Quizzes.Helpers;

namespace Domain.Modules.Quizzes.Specifications.Implementations.Questions;

internal class QuizQuestionsAreUniqueSpecification : ISpecification<IReadOnlyCollection<QuizQuestionSpecificationData>>
{
    public string FailureMessageCode => QuizMessages.NonUniqueQuestions();

    public bool IsValid(IReadOnlyCollection<QuizQuestionSpecificationData> data) =>
        QuizSpecificationHelper.AreQuestionsUnique(data);
}