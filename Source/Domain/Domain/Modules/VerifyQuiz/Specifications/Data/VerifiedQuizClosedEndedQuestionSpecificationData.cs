using Domain.Modules.VerifyQuiz.Enums;
using Domain.Modules.VerifyQuiz.ValueObjects;

namespace Domain.Modules.VerifyQuiz.Specifications.Data;

internal record VerifiedQuizClosedEndedQuestionSpecificationData(
    QuizClosedEndedQuestionType Type,
    IReadOnlyCollection<IQuizQuestionAnswer> AllValidatedAnswers,
    IReadOnlyCollection<IQuizQuestionAnswer> QuizQuestionAnswers
);