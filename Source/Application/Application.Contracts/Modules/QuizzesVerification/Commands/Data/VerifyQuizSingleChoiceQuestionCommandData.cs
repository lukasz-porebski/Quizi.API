using Common.Domain.ValueObjects;

namespace Application.Contracts.Modules.QuizzesVerification.Commands.Data;

public record VerifyQuizSingleChoiceQuestionCommandData(
    EntityNo No,
    int OrderNumber,
    VerifyQuizClosedQuestionAnswerCommandData? SelectedAnswer,
    IReadOnlyCollection<VerifyQuizClosedQuestionAnswerCommandData> UnselectedAnswers
);