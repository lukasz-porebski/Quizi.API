using Common.Domain.ValueObjects;
using Domain.Modules.VerifyQuiz.ValueObjects;

namespace Domain.Modules.VerifyQuiz.MethodData.Questions;

public record VerifyQuizSingleChoiceQuestionData(
    EntityNo No,
    int OrderNumber,
    QuizQuestionOrderedAnswer? SelectedAnswer,
    IReadOnlyCollection<QuizQuestionOrderedAnswer> UnselectedAnswers
) : VerifyQuizQuestionData(No, OrderNumber);