using Common.Domain.ValueObjects;

namespace Application.Contracts.Modules.QuizzesVerification.Commands.Data;

public record VerifyQuizClosedQuestionAnswerCommandData(
    EntityNo No,
    int OrderNumber
);