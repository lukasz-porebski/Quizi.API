namespace Domain.Modules.Quizzes.Specifications.Interfaces;

public interface IQuizQuestionsCountSpecification
{
    int QuestionsCount { get; }
    int QuestionsCountInRunningQuiz { get; }
}