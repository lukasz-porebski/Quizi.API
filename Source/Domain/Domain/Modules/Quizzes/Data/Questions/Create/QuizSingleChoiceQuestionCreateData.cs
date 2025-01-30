using Common.Shared.Extensions;
using Domain.Modules.Quizzes.ValueObjects;

namespace Domain.Modules.Quizzes.Data.Questions.Create;

public class QuizSingleChoiceQuestionCreateData : QuizQuestionData
{
    public QuizQuestionOrderedAnswer CorrectAnswer { get; }
    public List<QuizQuestionOrderedAnswer> WrongAnswers { get; }

    public QuizSingleChoiceQuestionCreateData(int orderNumber, string text,
        QuizQuestionOrderedAnswer correctAnswer, IEnumerable<QuizQuestionOrderedAnswer> wrongAnswers)
        : base(orderNumber, text)
    {
        CorrectAnswer = correctAnswer;
        WrongAnswers = wrongAnswers.CreateList();
    }
}