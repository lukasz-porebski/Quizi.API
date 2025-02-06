using Common.Domain.Entities;
using Common.Domain.Extensions;
using Common.Domain.ValueObjects;
using Domain.Modules.QuizResults.Data.Sub;

namespace Domain.Modules.QuizResults.Models;

public class QuizResultMultipleChoiceQuestion : BaseEntity
{
    private readonly List<QuizResultMultipleChoiceQuestionAnswer> _answers = [];

    internal QuizResultMultipleChoiceQuestion(AggregateId id, EntityNo no, QuizResultMultipleChoiceQuestionCreateDate data)
        : base(id, no)
    {
        OrdinalNumber = data.OrdinalNumber;
        Text = data.Text;
        ScoredPoints = data.ScoredPoints;
        PointsPossibleToGet = data.PointsPossibleToGet;
        _answers.ApplyNew(data.Answers, (subNo, a) => new QuizResultMultipleChoiceQuestionAnswer(id, no, subNo, a));
    }

    private QuizResultMultipleChoiceQuestion()
    {
    }

    public int OrdinalNumber { get; private set; }
    public string Text { get; private set; } = null!;
    public float ScoredPoints { get; private set; }
    public float PointsPossibleToGet { get; private set; }
    public IReadOnlyList<QuizResultMultipleChoiceQuestionAnswer> Answers => _answers;
}