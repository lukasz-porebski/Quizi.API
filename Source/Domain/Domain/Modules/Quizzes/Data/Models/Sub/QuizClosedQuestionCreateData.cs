using System.Collections.Generic;

namespace Domain.Modules.Quizzes.Data.Models.Sub;

public record QuizClosedQuestionCreateData(
    int OrdinalNumber,
    string Text,
    IReadOnlyCollection<QuizPersistClosedQuestionAnswerData> Answers
);