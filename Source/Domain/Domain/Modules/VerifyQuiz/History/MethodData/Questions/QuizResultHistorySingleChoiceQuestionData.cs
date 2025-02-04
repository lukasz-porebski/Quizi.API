using Domain.Modules.VerifyQuiz.ValueObjects;

namespace Domain.Modules.VerifyQuiz.History.MethodData.Questions;

public record QuizResultHistorySingleChoiceQuestionData(
    string Text,
    int OrderNumber,
    float ScoredPoints,
    float PointsPossibleToGet,
    IQuizQuestionAnswer? CorrectAnswerThatIsMarked,
    IQuizQuestionAnswer? CorrectAnswerThatIsNotMarked,
    IQuizQuestionAnswer? WrongAnswerThatIsMarked,
    IReadOnlyCollection<IQuizQuestionAnswer> WrongAnswersThatAreNotMarked
) : QuizResultHistoryQuestionData(Text, OrderNumber, ScoredPoints, PointsPossibleToGet);