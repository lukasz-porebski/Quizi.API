using Common.Domain.ValueObjects;
using Domain.Modules.Quizzes.Interfaces;

namespace Domain.Modules.Quizzes.Data.Questions.Update;

public record QuizSingleChoiceQuestionUpdateData(
    EntityNo? EntityNo,
    int OrderNumber,
    string Text,
    IReadOnlyCollection<QuizClosedQuestionAnswerUpdateData> Answers
) : IQuizQuestionUpdateData;