namespace PublishedLanguage.Modules.QuizzesVerification.Requests.Sub;

public record VerifyQuizOpenQuestionRequest(
    int No,
    int OrdinalNumber,
    string Answer,
    bool? IsCorrect
);