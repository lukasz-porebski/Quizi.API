using Common.Domain.ValueObjects;
using Common.Shared.Extensions;
using Domain.Modules.Quizzes.ValueObjects;

namespace Domain.Modules.Quizzes.Data.Questions.Update;

public class QuizSingleChoiceQuestionUpdateData : QuizQuestionUpdateData
{
    public QuizQuestionOrderedAnswer CorrectAnswer { get; }
    public List<QuizQuestionOrderedAnswer> WrongAnswers { get; }

    public QuizSingleChoiceQuestionUpdateData(EntityNo? entityNo, int orderNumber, string text,
        QuizQuestionOrderedAnswer correctAnswer, IEnumerable<QuizQuestionOrderedAnswer> wrongAnswers)
        : base(entityNo, orderNumber, text)
    {
        CorrectAnswer = correctAnswer;
        WrongAnswers = wrongAnswers.CreateList();
    }
}