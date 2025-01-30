using Common.Domain.Specification;
using Domain.Modules.Quizzes.Helpers;
using Domain.Modules.Quizzes.Specifications.Data.Questions;

namespace Domain.Modules.Quizzes.Specifications.Implementations;

internal class QuizAddNewQuestionsSpecification : ISpecification<QuizQuestionsForAddNewQuestionsSpecificationData>
{
    public string FailureMessageCode => QuizMessages.OneOfNewQuestionsIsAlreadyAdded();

    public bool IsValid(QuizQuestionsForAddNewQuestionsSpecificationData data)
    {
        var allQuestions = data.NewQuestions.Concat(data.OldQuestions);

        var areQuestionsUnique = QuizSpecificationHelper.AreQuestionsUnique(allQuestions);

        return areQuestionsUnique;
    }
}