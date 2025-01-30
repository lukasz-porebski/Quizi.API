using Domain.Modules.Quizzes.ValueObjects;

namespace Domain.Modules.Quizzes.Specifications.Data.Questions;

internal class QuizMultipleChoiceQuestionSpecificationData : QuizQuestionBaseSpecificationData
{
    internal List<QuizQuestionOrderedAnswer> CorrectAnswers { get; }
    internal List<QuizQuestionOrderedAnswer> WrongAnswers { get; }

    public QuizMultipleChoiceQuestionSpecificationData(int orderNumber, string text,
        List<QuizQuestionOrderedAnswer> correctAnswers, List<QuizQuestionOrderedAnswer> wrongAnswers)
        : base(orderNumber, text)
    {
        CorrectAnswers = correctAnswers;
        WrongAnswers = wrongAnswers;
    }
}