namespace Domain.Modules.VerifyQuiz.History.MethodData.Questions;

public record QuizResultHistoryOpenEndedQuestionData(
    string Text,
    int OrderNumber,
    float ScoredPoints,
    float PointsPossibleToGet,
    bool? IsCorrect,
    string CorrectAnswer,
    string UserAnswer
) : QuizResultHistoryQuestionData(Text, OrderNumber, ScoredPoints, PointsPossibleToGet);