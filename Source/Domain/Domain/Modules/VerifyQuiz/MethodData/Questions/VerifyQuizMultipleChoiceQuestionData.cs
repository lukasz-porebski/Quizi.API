using Common.Domain.ValueObjects;
using Domain.Modules.VerifyQuiz.ValueObjects;

namespace Domain.Modules.VerifyQuiz.MethodData.Questions;

public record VerifyQuizMultipleChoiceQuestionData(
    EntityNo No,
    int OrderNumber,
    IReadOnlyCollection<QuizQuestionOrderedAnswer> SelectedAnswers,
    IReadOnlyCollection<QuizQuestionOrderedAnswer> UnselectedAnswers
) : VerifyQuizQuestionData(No, OrderNumber);