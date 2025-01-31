using Domain.Modules.Quizzes.Helpers;
using Domain.Modules.Quizzes.Models;

namespace Domain.Modules.Quizzes.Data.Specifications.Questions;

public record QuizQuestionsForAddNewQuestionsSpecificationData
{
    public QuizQuestionsForAddNewQuestionsSpecificationData(
        IReadOnlyCollection<QuizOpenEndedQuestionSpecificationData> newOpenEndedQuestions,
        IReadOnlyCollection<QuizSingleChoiceQuestionSpecificationData> newSingleChoiceQuestions,
        IReadOnlyCollection<QuizMultipleChoiceQuestionSpecificationData> newMultipleChoiceQuestions,
        IReadOnlyCollection<OpenEndedQuestion> oldOpenEndedQuestions,
        IReadOnlyCollection<SingleChoiceQuestion> oldSingleChoiceQuestions,
        IReadOnlyCollection<MultipleChoiceQuestion> oldMultipleChoiceQuestions)
    {
        NewQuestions = QuizSpecificationHelper.GetQuestions(
            newOpenEndedQuestions, newSingleChoiceQuestions, newMultipleChoiceQuestions);
        OldQuestions = QuizSpecificationHelper.GetQuestions(
            oldOpenEndedQuestions, oldSingleChoiceQuestions, oldMultipleChoiceQuestions);
        NewClosedEndedQuestions = QuizSpecificationHelper.GetClosedEndedQuestions(
            newSingleChoiceQuestions, newMultipleChoiceQuestions);
    }

    public IReadOnlyCollection<QuizClosedEndedQuestionSpecificationData> NewClosedEndedQuestions { get; }
    public IReadOnlyCollection<QuizQuestionSpecificationData> NewQuestions { get; }
    public IReadOnlyCollection<QuizQuestionSpecificationData> OldQuestions { get; }

    public int GetAllQuestionsCount() => NewQuestions.Count + OldQuestions.Count;
}