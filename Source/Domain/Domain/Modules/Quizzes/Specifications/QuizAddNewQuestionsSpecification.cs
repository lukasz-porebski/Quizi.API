using Common.Domain.Specification;
using Domain.Modules.Quizzes.Constants;
using Domain.Modules.Quizzes.Data.Specifications.Questions;
using Domain.Modules.Quizzes.Helpers;

namespace Domain.Modules.Quizzes.Specifications;

internal class QuizAddNewQuestionsSpecification : ISpecification<QuizQuestionsForAddNewQuestionsSpecificationData>
{
    public string FailureMessageCode => QuizMessageCodes.OneOfNewQuestionsIsAlreadyAdded;

    public bool IsValid(QuizQuestionsForAddNewQuestionsSpecificationData data)
    {
        var allQuestions = data.NewQuestions.Concat(data.OldQuestions).ToArray();
        var areQuestionsUnique = QuizSpecificationHelper.AreQuestionsUnique(allQuestions);

        return areQuestionsUnique;
    }
}