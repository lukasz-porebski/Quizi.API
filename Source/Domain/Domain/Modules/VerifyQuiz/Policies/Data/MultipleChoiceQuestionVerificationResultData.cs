namespace Domain.Modules.VerifyQuiz.Policies.Data;

internal record MultipleChoiceQuestionVerificationResultData(
    int NumberOfCorrectAnswersMarked,
    int NumberOfWrongAnswersMarked
);