using Domain.Modules.Quizzes.Helpers;
using Domain.Modules.Quizzes.Models;

namespace Domain.Modules.Quizzes.Data.Specifications.Questions;

public record QuizQuestionsForAddNewQuestionsSpecificationData
{
    public QuizQuestionsForAddNewQuestionsSpecificationData(
        IReadOnlyCollection<QuizOpenQuestionSpecificationData> newOpenQuestions,
        IReadOnlyCollection<QuizSingleChoiceQuestionSpecificationData> newSingleChoiceQuestions,
        IReadOnlyCollection<QuizMultipleChoiceQuestionSpecificationData> newMultipleChoiceQuestions,
        IReadOnlyCollection<QuizOpenQuestion> oldOpenQuestions,
        IReadOnlyCollection<QuizSingleChoiceQuestion> oldSingleChoiceQuestions,
        IReadOnlyCollection<QuizMultipleChoiceQuestion> oldMultipleChoiceQuestions)
    {
        NewQuestions = QuizSpecificationHelper.GetQuestions(
            newOpenQuestions, newSingleChoiceQuestions, newMultipleChoiceQuestions);
        OldQuestions = QuizSpecificationHelper.GetQuestions(
            oldOpenQuestions, oldSingleChoiceQuestions, oldMultipleChoiceQuestions);
        NewClosedEndedQuestions = QuizSpecificationHelper.GetClosedEndedQuestions(
            newSingleChoiceQuestions, newMultipleChoiceQuestions);
    }

    public IReadOnlyCollection<QuizClosedQuestionSpecificationData> NewClosedEndedQuestions { get; }
    public IReadOnlyCollection<QuizQuestionSpecificationData> NewQuestions { get; }
    public IReadOnlyCollection<QuizQuestionSpecificationData> OldQuestions { get; }

    public int GetAllQuestionsCount() => NewQuestions.Count + OldQuestions.Count;
}