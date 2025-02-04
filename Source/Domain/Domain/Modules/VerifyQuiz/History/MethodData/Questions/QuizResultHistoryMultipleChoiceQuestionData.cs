using Domain.Modules.VerifyQuiz.ValueObjects;

namespace Domain.Modules.VerifyQuiz.History.MethodData.Questions;

public record QuizResultHistoryMultipleChoiceQuestionData(
    string Text,
    int OrderNumber,
    float ScoredPoints,
    float PointsPossibleToGet,
    IReadOnlyCollection<IQuizQuestionAnswer> CorrectAnswersThatAreMarked,
    IReadOnlyCollection<IQuizQuestionAnswer> CorrectAnswersThatAreNotMarked,
    IReadOnlyCollection<IQuizQuestionAnswer> WrongAnswersThatAreMarked,
    IReadOnlyCollection<IQuizQuestionAnswer> WrongAnswersThatAreNotMarked
) : QuizResultHistoryQuestionData(Text, OrderNumber, ScoredPoints, PointsPossibleToGet);