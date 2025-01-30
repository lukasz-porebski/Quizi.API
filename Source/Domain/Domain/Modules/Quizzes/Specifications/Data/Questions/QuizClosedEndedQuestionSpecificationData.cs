using Domain.Modules.Quizzes.Enums;
using Domain.Modules.Quizzes.ValueObjects;

namespace Domain.Modules.Quizzes.Specifications.Data.Questions;

internal class QuizClosedEndedQuestionSpecificationData
{
    internal QuizClosedEndedQuestionType Type { get; }
    internal string Text { get; }
    internal IEnumerable<QuizQuestionOrderedAnswer> Answers { get; }

    internal QuizClosedEndedQuestionSpecificationData(QuizClosedEndedQuestionType type,
        string text, IEnumerable<QuizQuestionOrderedAnswer> answers)
    {
        Type = type;
        Text = text;
        Answers = answers;
    }
}