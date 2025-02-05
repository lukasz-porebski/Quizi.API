namespace Domain.Modules.QuizzesVerification.Data.Sub;

public record MultipleChoiceQuestionVerificationResultData(
    int NumberOfCorrectAnswersMarked,
    int NumberOfWrongAnswersMarked
);