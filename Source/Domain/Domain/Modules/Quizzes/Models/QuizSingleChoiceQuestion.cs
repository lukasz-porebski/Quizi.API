using Common.Domain.Entities;
using Common.Domain.Extensions;
using Common.Domain.ValueObjects;
using Domain.Modules.Quizzes.Data.Models.Sub;

namespace Domain.Modules.Quizzes.Models;

public class QuizSingleChoiceQuestion : BaseEntity
{
    private readonly List<QuizSingleChoiceQuestionAnswer> _answers = [];

    internal QuizSingleChoiceQuestion(AggregateId id, EntityNo no, QuizClosedQuestionCreateData data) : base(id, no)
    {
        OrdinalNumber = data.OrdinalNumber;
        Text = data.Text;
        _answers.ApplyNew(data.Answers, (subNo, a) => new QuizSingleChoiceQuestionAnswer(id, no, subNo, a));
    }

    private QuizSingleChoiceQuestion()
    {
    }

    public int OrdinalNumber { get; private set; }
    public string Text { get; private set; } = null!;
    public IReadOnlyList<QuizSingleChoiceQuestionAnswer> Answers => _answers;

    public QuizSingleChoiceQuestionAnswer GetCorrectAnswer() =>
        Answers.First(a => a.IsCorrect);

    public IReadOnlyCollection<QuizSingleChoiceQuestionAnswer> GetWrongAnswers() =>
        Answers.Where(a => !a.IsCorrect).ToArray();

    internal void Update(QuizClosedQuestionUpdateData data)
    {
        OrdinalNumber = data.OrdinalNumber;
        Text = data.Text;

        _answers.ApplyChanges(
            data.Answers,
            (subNo, d) => new QuizSingleChoiceQuestionAnswer(Id, No, subNo, d.Data),
            (a, d) => a.Update(d.Data)
        );
    }
}