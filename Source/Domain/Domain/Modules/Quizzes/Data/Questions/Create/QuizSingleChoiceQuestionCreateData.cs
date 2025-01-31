using Domain.Modules.Quizzes.Interfaces;
using Domain.Modules.Quizzes.ValueObjects;

namespace Domain.Modules.Quizzes.Data.Questions.Create;

public record QuizSingleChoiceQuestionCreateData(
    int OrderNumber,
    string Text,
    QuizQuestionOrderedAnswer CorrectAnswer,
    IReadOnlyCollection<QuizQuestionOrderedAnswer> WrongAnswers
) : IQuizQuestionData;