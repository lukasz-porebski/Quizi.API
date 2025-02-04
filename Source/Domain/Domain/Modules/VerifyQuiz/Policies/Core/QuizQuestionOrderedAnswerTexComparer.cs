using Domain.Modules.VerifyQuiz.ValueObjects;

namespace Domain.Modules.VerifyQuiz.Policies.Core;

internal class QuizQuestionOrderedAnswerTexComparer : IEqualityComparer<IQuizQuestionAnswer>
{
    public bool Equals(IQuizQuestionAnswer? x, IQuizQuestionAnswer? y) =>
        string.Equals(x?.Text, y?.Text);

    public int GetHashCode(IQuizQuestionAnswer obj) =>
        HashCode.Combine(obj.Text);
}