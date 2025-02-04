using Common.Domain.ValueObjects;

namespace Domain.Modules.VerifyQuiz.MethodData.Questions;

public record VerifyQuizOpenEndedQuestionData(EntityNo No, int OrderNumber, bool? IsCorrect, string Answer)
    : VerifyQuizQuestionData(No, OrderNumber);