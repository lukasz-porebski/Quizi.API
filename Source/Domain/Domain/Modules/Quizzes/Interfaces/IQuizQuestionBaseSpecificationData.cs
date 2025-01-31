namespace Domain.Modules.Quizzes.Interfaces;

public interface IQuizQuestionBaseSpecificationData
{
    int OrderNumber { get; }
    string Text { get; }
}