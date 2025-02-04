namespace Domain.Modules.VerifyQuiz.History.MethodData.Questions;

public abstract record QuizResultHistoryQuestionData(
    string Text,
    int OrderNumber,
    float ScoredPoints,
    float PointsPossibleToGet
);