using System.Collections.Generic;
using Domain.Modules.Quizzes.Data.Models.Sub;
using Domain.Modules.Quizzes.Interfaces;
using Domain.Modules.Quizzes.ValueObjects;
using LP.Common.Domain.ValueObjects;

namespace Domain.Modules.Quizzes.Data.Models;

public record QuizCreateData(
    AggregateId OwnerId,
    string Title,
    string? Description,
    QuizSettings Settings,
    IReadOnlyCollection<QuizPersistOpenQuestionData> OpenQuestions,
    IReadOnlyCollection<QuizClosedQuestionCreateData> SingleChoiceQuestions,
    IReadOnlyCollection<QuizClosedQuestionCreateData> MultipleChoiceQuestions
) : IQuizPersistData;