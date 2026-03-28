using System;
using Domain.Contracts.Modules.Quizzes.Enums;
using LP.Common.Domain.Attributes;

namespace Domain.Modules.Quizzes.ValueObjects;

[ValueObject]
public record QuizSettings(
    TimeSpan Duration,
    int QuestionsCountInRunningQuiz,
    bool RandomQuestions,
    bool RandomAnswers,
    bool NegativePoints,
    QuizCopyMode CopyMode
);