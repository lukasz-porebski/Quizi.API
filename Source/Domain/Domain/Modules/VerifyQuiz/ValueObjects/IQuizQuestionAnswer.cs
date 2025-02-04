namespace Domain.Modules.VerifyQuiz.ValueObjects;

public interface IQuizQuestionAnswer
{
    int OrderNumber { get; }
    string Text { get; }
}