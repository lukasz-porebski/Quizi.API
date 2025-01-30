using Domain.Modules.Quizzes.Helpers;
using Domain.Modules.Quizzes.Models;

namespace Domain.Modules.Quizzes.Specifications.Data.Questions;

internal class QuizQuestionsForAddNewQuestionsSpecificationData
{
    internal IEnumerable<QuizClosedEndedQuestionSpecificationData> NewClosedEndedQuestions { get; }
    internal IEnumerable<QuizQuestionSpecificationData> NewQuestions { get; }
    internal IEnumerable<QuizQuestionSpecificationData> OldQuestions { get; }

    internal QuizQuestionsForAddNewQuestionsSpecificationData(
        IEnumerable<QuizOpenEndedQuestionSpecificationData> newOpenEndedQuestions,
        IEnumerable<QuizSingleChoiceQuestionSpecificationData> newSingleChoiceQuestions,
        IEnumerable<QuizMultipleChoiceQuestionSpecificationData> newMultipleChoiceQuestions,
        IEnumerable<OpenEndedQuestionEntity> oldOpenEndedQuestions,
        IEnumerable<SingleChoiceQuestionEntity> oldSingleChoiceQuestions,
        IEnumerable<MultipleChoiceQuestionEntity> oldMultipleChoiceQuestions)
    {
        NewQuestions = QuizSpecificationHelper.GetQuestions(
            newOpenEndedQuestions, newSingleChoiceQuestions, newMultipleChoiceQuestions);

        OldQuestions = QuizSpecificationHelper.GetQuestions(
            oldOpenEndedQuestions, oldSingleChoiceQuestions, oldMultipleChoiceQuestions);

        NewClosedEndedQuestions = QuizSpecificationHelper.GetClosedEndedQuestions(
            newSingleChoiceQuestions, newMultipleChoiceQuestions);
    }

    internal int GetAllQuestionsCount() => NewQuestions.Count() + OldQuestions.Count();
}