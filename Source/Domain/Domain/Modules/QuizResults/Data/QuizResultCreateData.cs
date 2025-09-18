using Common.Domain.ValueObjects;
using Domain.Modules.QuizResults.Data.Sub;
using Domain.Modules.Quizzes.Models;

namespace Domain.Modules.QuizResults.Data;

public record QuizResultCreateData(
    Quiz Quiz,
    AggregateId UserId,
    string Title,
    DateTimePeriod QuizRunningPeriod,
    TimeSpan MaxDuration,
    bool NegativePoints,
    bool RandomQuestions,
    bool RandomAnswers,
    IReadOnlyCollection<QuizResultOpenQuestionCreateData> OpenQuestions,
    IReadOnlyCollection<QuizResultSingleChoiceQuestionCreateDate> SingleChoiceQuestions,
    IReadOnlyCollection<QuizResultMultipleChoiceQuestionCreateDate> MultipleChoiceQuestions
);