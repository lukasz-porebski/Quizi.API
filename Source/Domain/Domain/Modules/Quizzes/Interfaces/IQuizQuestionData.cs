namespace Domain.Modules.Quizzes.Interfaces;

public interface IQuizQuestionData
{
    int OrderNumber { get; }
    string Text { get; }
}