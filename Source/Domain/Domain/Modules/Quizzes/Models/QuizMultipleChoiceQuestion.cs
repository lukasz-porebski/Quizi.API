using Common.Domain.Entities;
using Common.Domain.Extensions;
using Common.Domain.ValueObjects;
using Domain.Modules.Quizzes.Data.Models.Sub;

namespace Domain.Modules.Quizzes.Models;

public class QuizMultipleChoiceQuestion : BaseEntity
{
    private readonly List<QuizMultipleChoiceQuestionAnswer> _answers = [];

    internal QuizMultipleChoiceQuestion(AggregateId id, EntityNo no, QuizClosedQuestionCreateData data) : base(id, no)
    {
        OrdinalNumber = data.OrdinalNumber;
        Text = data.Text;
        _answers.ApplyNew(data.Answers, (subNo, a) => new QuizMultipleChoiceQuestionAnswer(id, no, subNo, a));
    }

    private QuizMultipleChoiceQuestion()
    {
    }

    public int OrdinalNumber { get; private set; }
    public string Text { get; private set; } = null!;
    public IReadOnlyList<QuizMultipleChoiceQuestionAnswer> Answers => _answers;

    public IReadOnlyCollection<QuizMultipleChoiceQuestionAnswer> GetCorrectAnswers() =>
        Answers.Where(a => a.IsCorrect).ToArray();

    public IReadOnlyCollection<QuizMultipleChoiceQuestionAnswer> GetWrongAnswers() =>
        Answers.Where(a => !a.IsCorrect).ToArray();
    
    internal void Update(QuizClosedQuestionPersistData data)
    {
        OrdinalNumber = data.OrdinalNumber;
        Text = data.Text;

        _answers.ApplyChanges(
            data.Answers,
            (subNo, d) => new QuizMultipleChoiceQuestionAnswer(Id, No, subNo, d.Data),
            (a, d) => a.Update(d.Data)
        );
    }
}