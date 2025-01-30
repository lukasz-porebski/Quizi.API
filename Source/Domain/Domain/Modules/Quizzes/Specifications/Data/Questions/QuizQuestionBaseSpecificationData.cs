namespace Domain.Modules.Quizzes.Specifications.Data.Questions;

internal abstract class QuizQuestionBaseSpecificationData
{
    internal int OrderNumber { get; }
    internal string Text { get; }

    protected QuizQuestionBaseSpecificationData(int orderNumber, string text)
    {
        OrderNumber = orderNumber;
        Text = text;
    }
}