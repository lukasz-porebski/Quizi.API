namespace Domain.Modules.Quizzes.Interfaces;

public interface IQuizClosedQuestionAnswer
{
    int OrderNumber { get; }
    string Text { get; }
    bool IsCorrect { get; }
}