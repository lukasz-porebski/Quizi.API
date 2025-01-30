using Domain.Modules.Quizzes.Extensions;

namespace Domain.Modules.Quizzes.Data.Questions;

public abstract class QuizQuestionData
{
    public int OrderNumber { get; }
    public string Text { get; }

    protected QuizQuestionData(int orderNumber, string text)
    {
        OrderNumber = orderNumber;
        Text = text.RemoveIllegalWhiteSpaces();
    }
}