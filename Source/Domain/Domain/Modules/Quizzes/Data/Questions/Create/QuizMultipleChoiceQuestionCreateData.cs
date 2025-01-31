using Domain.Modules.Quizzes.Interfaces;

namespace Domain.Modules.Quizzes.Data.Questions.Create;

public record QuizMultipleChoiceQuestionCreateData(
    int OrderNumber,
    string Text,
    IReadOnlyCollection<QuizClosedQuestionAnswerCreateData> Answers
) : IQuizQuestionData;