using Common.Domain.ValueObjects;

namespace Application.Contracts.Modules.QuizzesVerification.Commands.Data;

public record VerifyQuizSingleChoiceQuestionCommandData(
    EntityNo No,
    int OrdinalNumber,
    VerifyQuizClosedQuestionAnswerCommandData? SelectedAnswer,
    IReadOnlyCollection<VerifyQuizClosedQuestionAnswerCommandData> UnselectedAnswers
);