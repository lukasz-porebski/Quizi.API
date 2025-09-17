using Common.Domain.Specification;
using Domain.Modules.Quizzes.Constants;
using Domain.Modules.Quizzes.Data.Specifications.Sub;
using Domain.Modules.Quizzes.Helpers;

namespace Domain.Modules.Quizzes.Specifications.Questions;

internal class QuizQuestionsAreUniqueSpecification : ISpecification<IReadOnlyCollection<QuizQuestionSpecificationData>>
{
    public string FailureMessageCode => QuizMessageCodes.QuestionsHaveToBeUnique;

    public bool IsValid(IReadOnlyCollection<QuizQuestionSpecificationData> data) =>
        QuizSpecificationHelper.AreQuestionsUnique(data);
}