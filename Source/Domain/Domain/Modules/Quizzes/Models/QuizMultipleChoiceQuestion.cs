using Common.Domain.Entities;
using Common.Domain.ValueObjects;
using Common.Shared.Extensions;
using Domain.Modules.Quizzes.Data.Models.Questions.Create;
using Domain.Modules.Quizzes.Data.Models.Questions.Update;

namespace Domain.Modules.Quizzes.Models;

public class QuizMultipleChoiceQuestion : BaseEntity
{
    private readonly List<QuizClosedQuestionAnswer> _answers = [];

    internal QuizMultipleChoiceQuestion(AggregateId id, EntityNo no, QuizMultipleChoiceQuestionCreateData data) : base(id, no)
    {
        OrderNumber = data.OrderNumber;
        Text = data.Text;
        var subNo = EntityNo.Generate();
        _answers.Set(data.Answers.Select(a => new QuizClosedQuestionAnswer(id, no, subNo++, a)));
    }

    private QuizMultipleChoiceQuestion()
    {
    }

    public int OrderNumber { get; private set; }
    public string Text { get; private set; } = null!;
    public IReadOnlyList<QuizClosedQuestionAnswer> Answers => _answers;

    internal void Update(QuizMultipleChoiceQuestionUpdateData data)
    {
        //TODO: Zaimplementować
    }
}