using Common.Domain.ValueObjects;

namespace Domain.Modules.Quizzes.Data.Questions.Update;

public abstract record QuizQuestionUpdateData(EntityNo? EntityNo, int OrderNumber, string Text)
    : QuizQuestionData(OrderNumber, Text);