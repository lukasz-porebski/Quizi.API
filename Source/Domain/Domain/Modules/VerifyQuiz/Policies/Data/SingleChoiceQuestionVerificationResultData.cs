using Domain.Modules.VerifyQuiz.ValueObjects;

namespace Domain.Modules.VerifyQuiz.Policies.Data;

internal record SingleChoiceQuestionVerificationResultData(
    IQuizQuestionAnswer? CorrectAnswerThatIsMarked,
    IQuizQuestionAnswer? CorrectAnswerThatIsNotMarked,
    IQuizQuestionAnswer? WrongAnswerThatIsMarked,
    IReadOnlyList<IQuizQuestionAnswer> WrongAnswersThatAreNotMarked
);