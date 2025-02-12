using Common.Domain.ValueObjects;
using Common.Shared.DataStructures;
using Domain.Modules.QuizResults.Data.Sub;
using Domain.Modules.Quizzes.Models;

namespace Domain.Modules.QuizResults.Data;

public record QuizResultCreateData(
    Quiz Quiz,
    AggregateId UserId,
    string Title,
    Period<DateTime> QuizRunningPeriod,
    TimeSpan MaxDuration,
    bool NegativePoints,
    bool RandomQuestions,
    bool RandomAnswers,
    IReadOnlyCollection<QuizResultOpenQuestionCreateData> OpenQuestions,
    IReadOnlyCollection<QuizResultSingleChoiceQuestionCreateDate> SingleChoiceQuestions,
    IReadOnlyCollection<QuizResultMultipleChoiceQuestionCreateDate> MultipleChoiceQuestions
);