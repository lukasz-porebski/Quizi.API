using Common.Domain.Specification;
using Domain.Modules.Quizzes.Helpers;
using Domain.Modules.Quizzes.Specifications.Data.Questions;

namespace Domain.Modules.Quizzes.Specifications.Implementations.Questions;

internal class QuizQuestionsAreUniqueSpecification : ISpecification<IEnumerable<QuizQuestionSpecificationData>>
{
    public string FailureMessageCode => QuizMessages.NonUniqueQuestions();

    public bool IsValid(IEnumerable<QuizQuestionSpecificationData> data) =>
        QuizSpecificationHelper.AreQuestionsUnique(data);
}