namespace Infrastructure.Endpoints.Modules.Quizzes.Requests;

public record AddQuizUserRequest(
    string QuizId,
    string UserId
);