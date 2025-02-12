using Domain.Contracts.Modules.Quizzes.Enums;

namespace PublishedLanguage.Modules.Quizzes.Requests.Sub;

public record QuizSettingsPersistRequest(
    TimeSpan Duration,
    int QuestionsCountInRunningQuiz,
    bool RandomQuestions,
    bool RandomAnswers,
    bool NegativePoints,
    QuizCopyMode CopyMode
);