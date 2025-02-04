using Common.Domain.ValueObjects;

namespace Domain.Modules.VerifyQuiz.MethodData.Questions;

public abstract record VerifyQuizQuestionData(EntityNo No, int OrderNumber);