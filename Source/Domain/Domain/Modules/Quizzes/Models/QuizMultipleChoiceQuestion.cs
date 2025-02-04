using Common.Domain.Entities;
using Common.Domain.Extensions;
using Common.Domain.ValueObjects;
using Common.Shared.Extensions;
using Domain.Modules.Quizzes.Data.Models.Sub;

namespace Domain.Modules.Quizzes.Models;

public class QuizMultipleChoiceQuestion : BaseEntity
{
    private readonly List<QuizMultipleChoiceQuestionAnswer> _answers = [];

    internal QuizMultipleChoiceQuestion(AggregateId id, EntityNo no, QuizClosedQuestionCreateData data) : base(id, no)
    {
        OrderNumber = data.OrderNumber;
        Text = data.Text;
        var subNo = EntityNo.Generate();
        _answers.Set(data.Answers.Select(a => new QuizMultipleChoiceQuestionAnswer(id, no, subNo++, a)));
    }

    private QuizMultipleChoiceQuestion()
    {
    }

    public int OrderNumber { get; private set; }
    public string Text { get; private set; } = null!;
    public IReadOnlyList<QuizMultipleChoiceQuestionAnswer> Answers => _answers;

    internal void Update(QuizClosedQuestionPersistData data)
    {
        OrderNumber = data.OrderNumber;
        Text = data.Text;

        _answers.ApplyChanges(
            data.Answers,
            (subNo, d) => new QuizMultipleChoiceQuestionAnswer(Id, No, subNo, d.Data),
            (a, d) => a.Update(d.Data)
        );
    }
}