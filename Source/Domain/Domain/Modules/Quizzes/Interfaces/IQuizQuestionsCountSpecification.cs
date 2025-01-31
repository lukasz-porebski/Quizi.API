namespace Domain.Modules.Quizzes.Interfaces;

public interface IQuizQuestionsCountSpecification
{
    int QuestionsCount { get; }
    int QuestionsCountInRunningQuiz { get; }
}