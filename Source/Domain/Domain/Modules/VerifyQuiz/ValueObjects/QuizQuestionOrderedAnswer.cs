namespace Domain.Modules.VerifyQuiz.ValueObjects;

public readonly struct QuizQuestionOrderedAnswer : IQuizQuestionAnswer
{
    public int OrderNumber { get; }
    public string Text { get; }
}