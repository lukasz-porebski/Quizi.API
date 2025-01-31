using Common.Domain.ValueObjects;
using Domain.Modules.Quizzes.Enums;

namespace Domain.Modules.Quizzes.ValueObjects;

[ValueObject]
public record QuizSettings(
    TimeSpan Duration,
    int QuestionsCountInRunningQuiz,
    bool RandomQuestions,
    bool RandomAnswers,
    bool NegativePoints,
    QuizCopyMode QuizCopyMode
);