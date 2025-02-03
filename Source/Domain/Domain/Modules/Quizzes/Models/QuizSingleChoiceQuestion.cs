using Common.Domain.Entities;
using Common.Domain.Extensions;
using Common.Domain.ValueObjects;
using Common.Shared.Extensions;
using Domain.Modules.Quizzes.Data.Models.Sub;

namespace Domain.Modules.Quizzes.Models;

public class QuizSingleChoiceQuestion : BaseEntity
{
    private readonly List<QuizClosedQuestionAnswer> _answers = [];

    internal QuizSingleChoiceQuestion(AggregateId id, EntityNo no, QuizClosedQuestionPersistData data) : base(id, no)
    {
        OrderNumber = data.OrderNumber;
        Text = data.Text;
        var subNo = EntityNo.Generate();
        _answers.Set(data.Answers.Select(a => new QuizClosedQuestionAnswer(id, no, subNo++, a.Data)));
    }

    private QuizSingleChoiceQuestion()
    {
    }

    public int OrderNumber { get; private set; }
    public string Text { get; private set; } = null!;
    public IReadOnlyList<QuizClosedQuestionAnswer> Answers => _answers;

    internal void Update(QuizClosedQuestionPersistData data)
    {
        OrderNumber = data.OrderNumber;
        Text = data.Text;

        _answers.ApplyChanges(
            data.Answers,
            (subNo, d) => new QuizClosedQuestionAnswer(Id, No, subNo, d.Data),
            (a, d) => a.Update(d.Data)
        );
    }
}