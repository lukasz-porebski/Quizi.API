using Domain.Modules.VerifyQuiz.ValueObjects;

namespace Domain.Modules.VerifyQuiz.Policies.Data;

internal record MultipleChoiceQuestionVerificationResultData(
    IReadOnlyCollection<IQuizQuestionAnswer> CorrectAnswersThatAreMarked,
    IReadOnlyCollection<IQuizQuestionAnswer> CorrectAnswersThatAreNotMarked,
    IReadOnlyCollection<IQuizQuestionAnswer> WrongAnswersThatAreMarked,
    IReadOnlyCollection<IQuizQuestionAnswer> WrongAnswersThatAreNotMarked
);