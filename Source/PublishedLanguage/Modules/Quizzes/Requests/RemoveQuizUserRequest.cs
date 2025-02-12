namespace PublishedLanguage.Modules.Quizzes.Requests;

public record RemoveQuizUserRequest(
    string QuizId,
    string UserId
);