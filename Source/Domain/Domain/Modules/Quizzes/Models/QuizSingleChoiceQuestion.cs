using Common.Domain.Entities;
using Common.Domain.ValueObjects;
using Common.Shared.Extensions;
using Domain.Modules.Quizzes.Data.Questions.Create;
using Domain.Modules.Quizzes.Data.Questions.Update;

namespace Domain.Modules.Quizzes.Models;

public class QuizSingleChoiceQuestion : BaseEntity
{
    private readonly List<QuizClosedQuestionAnswer> _answers = [];

    internal QuizSingleChoiceQuestion(AggregateId id, EntityNo no, QuizSingleChoiceQuestionCreateData data) : base(id, no)
    {
        OrderNumber = data.OrderNumber;
        Text = data.Text;
        var subNo = EntityNo.Generate();
        _answers.Set(data.Answers.Select(a => new QuizClosedQuestionAnswer(id, no, subNo++, a)));
    }

    private QuizSingleChoiceQuestion()
    {
    }

    public int OrderNumber { get; private set; }
    public string Text { get; private set; } = null!;
    public IReadOnlyList<QuizClosedQuestionAnswer> Answers => _answers;

    internal void Update(QuizSingleChoiceQuestionUpdateData data)
    {
        //TODO: Zaimplementować
    }
}