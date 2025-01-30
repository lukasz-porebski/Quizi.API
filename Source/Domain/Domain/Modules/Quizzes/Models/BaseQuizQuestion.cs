using Common.Domain.Entities;
using Common.Domain.ValueObjects;
using Domain.Modules.Quizzes.Data.Questions;

namespace Domain.Modules.Quizzes.Models;

public abstract class BaseQuizQuestion : BaseEntity
{
    internal BaseQuizQuestion(AggregateId id, EntityNo no, QuizQuestionData data)
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

    internal void Update(QuizQuestionData data)
    {
        OrderNumber = data.OrderNumber;
        Text = data.Text;
    }
}