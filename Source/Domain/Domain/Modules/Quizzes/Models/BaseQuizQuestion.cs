using Common.Domain.Entities;
using Common.Domain.ValueObjects;
using Domain.Modules.Quizzes.Interfaces;

namespace Domain.Modules.Quizzes.Models;

public abstract class BaseQuizQuestion : BaseEntity
{
    internal BaseQuizQuestion(AggregateId id, EntityNo no, IQuizQuestionData data)
        : base(id, no)
    {
        OrderNumber = data.OrderNumber;
        Text = data.Text;
    }

    protected BaseQuizQuestion()
    {
    }

    public int OrderNumber { get; private set; }
    public string Text { get; private set; } = null!;

    internal void Update(IQuizQuestionData data)
    {
        OrderNumber = data.OrderNumber;
        Text = data.Text;
    }
}