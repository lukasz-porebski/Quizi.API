namespace Domain.Modules.Quizzes.Specifications.Data.Questions;

internal class QuizQuestionSpecificationData : QuizQuestionBaseSpecificationData
{
    internal IEnumerable<string> Answers { get; }

    internal QuizQuestionSpecificationData(int orderNumber, string text, IEnumerable<string> answers)
        : base(orderNumber, text)
    {
        Answers = answers;
    }
}