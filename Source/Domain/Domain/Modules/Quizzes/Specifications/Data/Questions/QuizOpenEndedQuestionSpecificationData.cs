namespace Domain.Modules.Quizzes.Specifications.Data.Questions;

internal class QuizOpenEndedQuestionSpecificationData : QuizQuestionBaseSpecificationData
{
    internal string CorrectAnswer { get; }

    public QuizOpenEndedQuestionSpecificationData(int orderNumber, string text, string correctAnswer)
        : base(orderNumber, text)
    {
        CorrectAnswer = correctAnswer;
    }
}