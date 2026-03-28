using System.Collections.Generic;
using Domain.Modules.Quizzes.Data.Models.Sub;
using LP.Common.Domain.ValueObjects;

namespace Domain.Modules.Quizzes.Data.Models;

public record QuizAddNewQuestionsData(
    AggregateId UserId,
    int QuestionsCountInRunningQuiz,
    IReadOnlyCollection<QuizPersistOpenQuestionData> OpenQuestions,
    IReadOnlyCollection<QuizClosedQuestionCreateData> SingleChoiceQuestions,
    IReadOnlyCollection<QuizClosedQuestionCreateData> MultipleChoiceQuestions
);