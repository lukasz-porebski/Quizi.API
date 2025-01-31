using Domain.Modules.Quizzes.Interfaces;

namespace Domain.Modules.Quizzes.Data.Questions.Create;

public record QuizSingleChoiceQuestionCreateData(
    int OrderNumber,
    string Text,
    IReadOnlyCollection<QuizClosedQuestionAnswerCreateData> Answers
) : IQuizQuestionData;