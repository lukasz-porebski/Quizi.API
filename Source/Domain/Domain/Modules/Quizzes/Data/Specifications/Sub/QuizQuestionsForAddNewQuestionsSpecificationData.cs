using Domain.Modules.Quizzes.Data.Models.Sub;
using Domain.Modules.Quizzes.Helpers;
using Domain.Modules.Quizzes.Models;

namespace Domain.Modules.Quizzes.Data.Specifications.Sub;

public record QuizQuestionsForAddNewQuestionsSpecificationData
{
    public QuizQuestionsForAddNewQuestionsSpecificationData(
        IReadOnlyCollection<QuizOpenQuestionPersistData> newOpenQuestions,
        IReadOnlyCollection<QuizClosedQuestionCreateData> newSingleChoiceQuestions,
        IReadOnlyCollection<QuizClosedQuestionCreateData> newMultipleChoiceQuestions,
        IReadOnlyCollection<QuizOpenQuestion> oldOpenQuestions,
        IReadOnlyCollection<QuizSingleChoiceQuestion> oldSingleChoiceQuestions,
        IReadOnlyCollection<QuizMultipleChoiceQuestion> oldMultipleChoiceQuestions)
    {
        NewQuestions = QuizSpecificationHelper.GetQuestions(newOpenQuestions, newSingleChoiceQuestions, newMultipleChoiceQuestions);
        OldQuestions = QuizSpecificationHelper.GetQuestions(oldOpenQuestions, oldSingleChoiceQuestions, oldMultipleChoiceQuestions);
        NewClosedQuestions = newSingleChoiceQuestions.Concat(newMultipleChoiceQuestions).ToArray();
    }

    public IReadOnlyCollection<QuizClosedQuestionCreateData> NewClosedQuestions { get; }
    public IReadOnlyCollection<QuizQuestionSpecificationData> NewQuestions { get; }
    public IReadOnlyCollection<QuizQuestionSpecificationData> OldQuestions { get; }
}