using Domain.Contracts.Modules.Quizzes.Enums;

namespace PublishedLanguage.Modules.Quizzes.Responses;

public record QuizzesListItemResponse(
    string Id,
    string Title,
    TimeSpan Duration,
    Guid Code,
    QuizCopyMode CopyMode,
    int QuestionsCount,
    int QuestionsCountInRunningQuiz
);