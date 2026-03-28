using System;
using System.Collections.Generic;
using Domain.Modules.QuizResults.Data.Sub;
using Domain.Modules.Quizzes.Models;
using LP.Common.Domain.ValueObjects;

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