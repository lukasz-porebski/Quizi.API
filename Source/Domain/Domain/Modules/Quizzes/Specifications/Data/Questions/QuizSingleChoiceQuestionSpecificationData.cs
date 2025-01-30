using Domain.Modules.Quizzes.ValueObjects;

namespace Domain.Modules.Quizzes.Specifications.Data.Questions;

internal class QuizSingleChoiceQuestionSpecificationData : QuizQuestionBaseSpecificationData
{
    internal QuizQuestionOrderedAnswer CorrectAnswer { get; }
    internal List<QuizQuestionOrderedAnswer> WrongAnswers { get; }

    public QuizSingleChoiceQuestionSpecificationData(int orderNumber, string text,
        QuizQuestionOrderedAnswer correctAnswer, List<QuizQuestionOrderedAnswer> wrongAnswers)
        : base(orderNumber, text)
    {
        CorrectAnswer = correctAnswer;
        WrongAnswers = wrongAnswers;
    }
}