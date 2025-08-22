using Domain.Contracts.Modules.Quizzes.Enums;

namespace Application.Contracts.Modules.Quizzes.Dtos;

public record QuizzesListItemDto(
    string Id,
    string Title,
    TimeSpan Duration,
    QuizCopyMode CopyMode,
    int QuestionsCount,
    int QuestionsCountInRunningQuiz
);