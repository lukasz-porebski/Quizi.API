using Common.Domain.ValueObjects;

namespace Application.Contracts.Modules.QuizzesVerification.Commands.Data;

public record VerifyQuizOpenQuestionCommandData(
    EntityNo No,
    int OrdinalNumber,
    string Answer,
    bool? IsCorrect
);