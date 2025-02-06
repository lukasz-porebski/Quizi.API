using Common.Domain.ValueObjects;

namespace Application.Contracts.Modules.QuizzesVerification.Commands.Data;

public record VerifyQuizMultipleChoiceQuestionCommandData(
    EntityNo No,
    int OrderNumber,
    IReadOnlyCollection<VerifyQuizClosedQuestionAnswerCommandData> SelectedAnswers,
    IReadOnlyCollection<VerifyQuizClosedQuestionAnswerCommandData> UnselectedAnswers
);