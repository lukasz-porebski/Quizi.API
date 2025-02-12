namespace PublishedLanguage.Modules.QuizResults.Requests.Sub;

public record VerifyQuizOpenQuestionRequest(
    int No,
    int OrdinalNumber,
    string Answer,
    bool? IsCorrect
);