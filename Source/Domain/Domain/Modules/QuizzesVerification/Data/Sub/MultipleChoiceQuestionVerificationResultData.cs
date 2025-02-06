namespace Domain.Modules.QuizzesVerification.Data.Sub;

public record MultipleChoiceQuestionVerificationResultData(
    int NumberOfSelectedCorrectAnswers,
    int NumberOfSelectedWrongAnswers
);