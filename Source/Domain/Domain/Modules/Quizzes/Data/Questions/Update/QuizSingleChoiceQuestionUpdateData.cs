using Common.Domain.ValueObjects;
using Domain.Modules.Quizzes.ValueObjects;

namespace Domain.Modules.Quizzes.Data.Questions.Update;

public record QuizSingleChoiceQuestionUpdateData(
    EntityNo? EntityNo,
    int OrderNumber,
    string Text,
    QuizQuestionOrderedAnswer CorrectAnswer,
    IReadOnlyCollection<QuizQuestionOrderedAnswer> WrongAnswers
) : QuizQuestionUpdateData(EntityNo, OrderNumber, Text);