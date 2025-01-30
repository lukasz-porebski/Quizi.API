using Common.Shared.Extensions;
using Domain.Modules.Quizzes.ValueObjects;

namespace Domain.Modules.Quizzes.Data.Questions.Create;

public class QuizMultipleChoiceQuestionCreateData : QuizQuestionData
{
    public List<QuizQuestionOrderedAnswer> CorrectAnswers { get; }
    public List<QuizQuestionOrderedAnswer> WrongAnswers { get; }

    public QuizMultipleChoiceQuestionCreateData(int orderNumber, string text,
        IEnumerable<QuizQuestionOrderedAnswer> correctAnswers, IEnumerable<QuizQuestionOrderedAnswer> wrongAnswers)
        : base(orderNumber, text)
    {
        CorrectAnswers = correctAnswers.CreateList();
        WrongAnswers = wrongAnswers.CreateList();
    }
}