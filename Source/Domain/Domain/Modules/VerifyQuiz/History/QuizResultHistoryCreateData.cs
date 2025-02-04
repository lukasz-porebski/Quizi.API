using Common.Domain.ValueObjects;
using Domain.Modules.VerifyQuiz.History.MethodData.Questions;

namespace Domain.Modules.VerifyQuiz.History;

public record QuizResultHistoryCreateData(
    AggregateId Id,
    AggregateId QuizId,
    AggregateId UserId,
    DateTime FinishDate,
    string Title,
    int QuizFinishTimeInSeconds,
    int TimeForQuizInSeconds,
    bool NegativePoints,
    int AllQuestionsCount,
    bool RandomQuestions,
    bool RandomAnswers,
    QuizResultHistoryQuestionsData Questions
);