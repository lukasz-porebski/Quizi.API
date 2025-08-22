using Domain.Contracts.Modules.Quizzes.Enums;

namespace PublishedLanguage.Modules.Quizzes.Responses;

public record QuizzesListItemResponse(
    string Id,
    string Title,
    TimeSpan Duration,
    QuizCopyMode CopyMode,
    int QuestionsCount,
    int QuestionsCountInRunningQuiz
);