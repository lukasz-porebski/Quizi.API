using Common.Domain.ValueObjects;
using Domain.Modules.VerifyQuiz.MethodData.Questions;

namespace Domain.Modules.VerifyQuiz.MethodData;

public record VerifyQuizData(
    AggregateId QuizId,
    AggregateId UserId,
    AggregateId QuizResultHistoryId,
    int QuizFinishTimeInSeconds,
    IReadOnlyCollection<VerifyQuizOpenEndedQuestionData> OpenEndedQuestions,
    IReadOnlyCollection<VerifyQuizSingleChoiceQuestionData> SingleChoiceQuestions,
    IReadOnlyCollection<VerifyQuizMultipleChoiceQuestionData> MultipleChoiceQuestions
);