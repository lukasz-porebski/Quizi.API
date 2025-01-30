using Common.Domain.ValueObjects;
using Common.Shared.Extensions;
using Domain.Modules.Quizzes.ValueObjects;

namespace Domain.Modules.Quizzes.Data.Questions.Update;

public class QuizMultipleChoiceQuestionUpdateData : QuizQuestionUpdateData
{
    public List<QuizQuestionOrderedAnswer> CorrectAnswers { get; }
    public List<QuizQuestionOrderedAnswer> WrongAnswers { get; }

    public QuizMultipleChoiceQuestionUpdateData(EntityNo? entityNo, int orderNumber, string text,
        IEnumerable<QuizQuestionOrderedAnswer> correctAnswers, IEnumerable<QuizQuestionOrderedAnswer> wrongAnswers)
        : base(entityNo, orderNumber, text)
    {
        CorrectAnswers = correctAnswers.CreateList();
        WrongAnswers = wrongAnswers.CreateList();
    }
}