using Domain.Contracts.Modules.Quizzes.Enums;

namespace Application.Contracts.Modules.Quizzes.Dtos;

public class QuizzesListItemDto
{
    public required string Id { get; set; }
    public required string Title { get; set; }
    public TimeSpan Duration { get; set; }
    public QuizCopyMode CopyMode { get; set; }
    public int QuestionsCount { get; set; }
    public int QuestionsCountInRunningQuiz { get; set; }
}